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
        
        public Game CreateGame(Guid playerGuid, GameTypeEnum gameType, DateTime? date = null)
        {
            var player = _context.Players
                .FirstOrDefault(x => x.Guid == playerGuid);
            if (player is null)
            {
                player = new Player { Guid = playerGuid };
                _context.Players.Add(player);
                _context.SaveChanges();
            }

            //Return the game if it already exists
            Word word;
            if (gameType == GameTypeEnum.WordOfTheDay)
            {
                if (date == null) throw new ArgumentException("Date cannot be null if the game type is WordOfTheDay");
                
                var existingGame = _context.Games
                    .Include(x => x.Guesses)
                    .Include(x => x.Word)
                    .FirstOrDefault(x => x.PlayerId == player.PlayerId &&
                                         x.GameType == GameTypeEnum.WordOfTheDay &&
                                         x.DateEnded.HasValue &&
                                         x.WordDate == date.Value);
                if (existingGame is not null)
                {
                    return existingGame;
                }
                // If this is a new game, get the word of the day.
                word = GetDailyWord(date.Value) ?? throw new ArgumentException("Date is too far in the future");
            }
            else
            {
                // If this is a new game, get a random word.
                word = GetWord();
            }

            var game = new Game()
            {
                WordId = word.WordId,
                PlayerId = player.PlayerId,
                DateStarted = DateTime.UtcNow,
                GameType = gameType,
                WordDate = date
            };
            _context.Games.Add(game);

            _context.SaveChanges();

            return game;

        }

        public void FinishGame(int gameId)
        {
            var game = _context.Games
                .FirstOrDefault(x => x.GameId == gameId);
            if (game is null) throw new ArgumentException("Game does not exist");

            game.DateEnded = DateTime.UtcNow;
            _context.SaveChanges();
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
                return null;
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
    }
}
