using Wordle.Api.Data;
using System.Linq;
using static Wordle.Api.Data.Game;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;

namespace Wordle.Api.Services
{
    public class GameService
    {
        private readonly AppDbContext _context;
        private readonly static object _mutex = new();
        private static readonly ConcurrentDictionary<DateTime, Word> _cache = new();

        public GameService(AppDbContext context)
        {
            _context = context;
        }

        public Game? GetGame(Player player, GameTypeEnum gameType, DateTime dateTime)
        {
            return _context.Games.FirstOrDefault(x => x.PlayerId == player.PlayerId &&
                                                    x.GameType == GameTypeEnum.WordOfTheDay &&
                                                    x.DateStarted.Date == dateTime.Date);
        }

        public Game? GetGame(int gameId)
        {
            return _context.Games.FirstOrDefault(item => item.GameId == gameId);
        }

        public Game CreateGame(Player player, GameTypeEnum gameType, DateTime date)
        {
            Word word = (gameType == GameTypeEnum.WordOfTheDay ? GetDailyWord(date) : GetWord()) ?? throw new ArgumentException("Date must not be in the future");
            Game game = new Game
            {
                PlayerId = player.PlayerId,
                Player = player,
                WordId = word.WordId,
                Word = word.Value,
                DateStarted = date.Date,
                GameType = gameType
            };
            _context.Games.Add(game);
            _context.SaveChanges();
            return game;
        }

        public Game FinishGame(int gameId)
        {
            var game = _context.Games
                .FirstOrDefault(x => x.GameId == gameId);
            if (game is null) throw new ArgumentException("Game does not exist");

            game.DateEnded = DateTime.UtcNow;
            _context.SaveChanges();
            return game;
        }

        public Word GetWord()
        {
            int wordCount = _context.Words.Count(f => f.Common);
            int randomIndex = new Random().Next(0, wordCount);
            Word chosenWord = _context.Words
                .Where(f => f.Common)
                .OrderBy(w => w.WordId)
                .Skip(randomIndex)
                .Take(1)
                .First();
            return chosenWord;
        }

        public Word? GetDailyWord(DateTime date)
        {
            //Sanitize the date by dropping time data
            date = date.Date;
            if (date.ToUniversalTime() >= System.DateTime.Today.ToUniversalTime().AddDays(0.5))
            {
                date = System.DateTime.Today;
            }
            //Check if the day has a word in the database
            if (_cache.TryGetValue(date, out var word))
            {
                return word;
            }
            DateWord? wordOfTheDay = _context.DateWords
                .Include(x => x.Word)
                .FirstOrDefault(dw => dw.Date == date);

            if (wordOfTheDay != null)
            //Yes: return the word
            {
                _cache.TryAdd(date, wordOfTheDay.Word);
                return wordOfTheDay.Word;
            }
            else
            {
                //Mutex magic
                lock (_mutex)
                {
                    wordOfTheDay = _context.DateWords
                        .Include(x => x.Word)
                        .FirstOrDefault(dw => dw.Date == date);
                    if (wordOfTheDay != null)
                    //Yes: return the word
                    {
                        return wordOfTheDay.Word;
                    }
                    else
                    {
                        //No: get a random word from our list
                        var chosenWord = GetWord();
                        //Save the word to the database with the date
                        _context.DateWords.Add(new DateWord { Date = date, Word = chosenWord });
                        _context.SaveChanges();
                        //Return the word
                        _cache.TryAdd(date, chosenWord);
                        return chosenWord;
                    }
                }
            }
        }
        
        public IEnumerable<string?> GetWotdPlayers(int dailyWordId)
        {
            var dateWord = _context.DateWords
                .Include(x => x.Word.Games)
                .ThenInclude(x => x.Player)
                .FirstOrDefault(x => x.WordId == dailyWordId);
            if (dateWord is null) throw new ArgumentException("DateWord does not exist");
            return dateWord.Word.Games.Select(x => x.Player.Name);
        }
    }
}
