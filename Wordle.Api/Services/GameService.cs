using Wordle.Api.Data;
using System.Linq;

namespace Wordle.Api.Services
{
    public class GameService
    {
        private readonly AppDbContext _context;

        public GameService(AppDbContext context)
        {
            _context = context;
        }
        
        public Game CreateGame(Guid guid)  
        {
            var player = _context.Players
                .FirstOrDefault(x => x.Guid == guid);
            if (player is null)
            {
                player = new Player { Guid = guid };
                _context.Players.Add(player);
                _context.SaveChanges();
            }

            var game = new Game()
            {
                Word = GetWord(),
                Player = player,
                DateStarted = DateTime.UtcNow
            };

            _context.SaveChanges();

            return game;
            
        }

        public Word GetWord()
        {
            int wordCount = _context.Words.Count(f=>f.Common);
            int randomIndex = new Random().Next(0, wordCount);
            Word chosenWord = _context.Words
                .Where(f => f.Common)
                .OrderBy(w => w.WordId)
                .Skip(randomIndex)
                .Take(1)
                .First();
            return chosenWord;
        }
    }
}
