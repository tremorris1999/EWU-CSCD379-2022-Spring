using Wordle.Api.Data;

namespace Wordle.Api.Services;

public class PlayersService
{
    private readonly AppDbContext _context;

    public PlayersService(AppDbContext context)
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
            .OrderBy(x => x.AverageAttempts / x.GameCount)
            .ThenBy(x => x.AverageSecondsPerGame / x.GameCount)
            .ThenBy(x => x.AverageAttempts)
            .ThenByDescending(x => x.GameCount)
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

        var player2 = _context.Players;
        
        var player = player2.FirstOrDefault(x => x.Name == name);


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
        if (!context.Players.Any())
        {
            context.Players.Add(new Player()
            {
                Name = "Inigo Montoya",
                GameCount = 2,
                AverageAttempts = 2,
                AverageSecondsPerGame = 31
            });
            context.SaveChanges();
        }
    }
}
