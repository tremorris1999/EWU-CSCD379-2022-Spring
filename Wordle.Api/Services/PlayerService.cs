using Wordle.Api.Data;

namespace Wordle.Api.Services;

public class PlayerService
{
    private AppDbContext _context;

    public PlayerService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Player> GetPlayers()
    {
        var result = _context.Players.OrderBy(x => x.Name);
        return result;
    }

    public IEnumerable<Player> GetTop10Players()
    {
        var result = _context.Players
            .OrderBy(x => x.AverageAttempts * x.GameCount)
            .ThenBy(x => x.AverageSecondsPerGame * x.GameCount)
            .Take(10);
        return result;
    }

    public void Update(string name, int attempts, int seconds)
    {
        if (attempts < 1 || attempts > 6)
        {
            throw new ArgumentException("attempts not in proper range");
        }
        if (seconds < 0)
        {
            throw new ArgumentException("seconds not in proper range");
        }

        var player = _context.Players.First(x => x.Name.Equals(name));
        
        if (player == null)
        {
            _context.Players.Add(new Player()
            {
                Name = name,
                GameCount = 1,
                AverageAttempts = attempts,
                AverageSecondsPerGame = seconds
            });
        }
        else
        {
            player.AverageSecondsPerGame = (player.AverageSecondsPerGame * player.GameCount + seconds) / (player.GameCount + 1);
            player.AverageAttempts = (player.AverageAttempts * player.GameCount + attempts) / ++player.GameCount;

        }

        _context.SaveChanges();
    }

    public static void Seed(AppDbContext context)
    {
        if (!context.Players.Any())//method is crashing. why?
        {
            context.Players.Add(new Player()
            {
                Name = "S. Morgenstern",
                GameCount = 5,
                AverageAttempts = 2.2,
                AverageSecondsPerGame = 5
            });

            context.Players.Add(new Player()
            {
                Name = "Buttercup",
                GameCount = 1,
                AverageAttempts = 5,
                AverageSecondsPerGame = 60
            });

            context.Players.Add(new Player()
            {
                Name = "Westley",
                GameCount = 10,
                AverageAttempts = 5.2,
                AverageSecondsPerGame = 120
            });

            context.Players.Add(new Player()
            {
                Name = "Prince Humperdinck",
                GameCount = 48,
                AverageAttempts = 2.75,
                AverageSecondsPerGame = 82
            });

            context.Players.Add(new Player()
            {
                Name = "Vizzini",
                GameCount = 36,
                AverageAttempts = 1.5,
                AverageSecondsPerGame = 225
            });



            context.Players.Add(new Player()
            {
                Name = "Fezzik",
                GameCount = 34,
                AverageAttempts = 1.5,
                AverageSecondsPerGame = 198
            });

            context.Players.Add(new Player()
            {
                Name = "Inigo Montoya",
                GameCount = 60,
                AverageAttempts = 4.25,
                AverageSecondsPerGame = 273
            });

            context.Players.Add(new Player()
            {
                Name = "Count Rugen",
                GameCount = 14,
                AverageAttempts = 2.5,
                AverageSecondsPerGame = 76
            });

            context.Players.Add(new Player()
            {
                Name = "King Lotharon",
                GameCount = 56,
                AverageAttempts = 5.5,
                AverageSecondsPerGame = 251
            });

            context.Players.Add(new Player()
            {
                Name = "Queen Bella",
                GameCount = 8,
                AverageAttempts = 1.5,
                AverageSecondsPerGame = 167
            });

            context.Players.Add(new Player()
            {
                Name = "Miracle Max",
                GameCount = 50,
                AverageAttempts = 2.64,
                AverageSecondsPerGame = 64
            });

            context.Players.Add(new Player()
            {
                Name = "Valerie",
                GameCount = 6,
                AverageAttempts = 2,
                AverageSecondsPerGame = 297
            });


            context.SaveChanges();
        }
    }
}
