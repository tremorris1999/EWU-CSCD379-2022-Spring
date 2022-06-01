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

    public Player? GetPlayer(string name)
    {
        return _context.Players.FirstOrDefault(item => item.Name == name);
    }

    public Player? GetPlayer(int playerId)
    {
        return _context.Players.FirstOrDefault(item => item.PlayerId == playerId);
    }

    public IEnumerable<Player> GetTop10Players()
    {
        var result = _context.Players
            .OrderBy(x => x.AverageAttempts)
            .ThenBy(x => x.AverageSecondsPerGame)
            .ThenBy(x => x.GameCount)
            .Where(x => x.AverageAttempts > 0)
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
            context.Players.Add(new Player()
            {
                Name = "uHH A",
                GameCount = 4,
                AverageAttempts = 3,
                AverageSecondsPerGame = 21
            });
            context.Players.Add(new Player()
            {
                Name = "brrrt",
                GameCount = 4,
                AverageAttempts = 1,
                AverageSecondsPerGame = 1000
            });
            context.SaveChanges();
        }
    }
}