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
            return _context.Players
                .AsEnumerable()
                .OrderBy(item => item.AverageGuesses);
    }

    public void Update(string name, int guesses, int seconds)
    {
        if(guesses < 1 || guesses > 6){
            throw new ArgumentException("Guesses must be between 1 and 6");
        }
        if(seconds < 1)
        {
            throw new ArgumentException("Seconds must be greater than 0");
        }
        
        Player? player = _context.Players.FirstOrDefault(item => item.Name!.CompareTo(name) == 0);
        if (player != null)
        {
            double aggregateGuesses = (player.AverageGuesses * player.GameCount) + guesses;
            int aggregateSeconds = (player.AverageSecondsPerGame * player.GameCount) + seconds;
            player.GameCount += 1;
            player.AverageGuesses = aggregateGuesses / player.GameCount;
            player.AverageSecondsPerGame = aggregateSeconds / player.GameCount;
        }
        else
            _context.Players.Add(new Player()
            {
                Name = name,
                GameCount = 1,
                AverageGuesses = guesses,
                AverageSecondsPerGame = seconds
            });
        
        _context.SaveChanges();
    }

    public static void Seed(AppDbContext context)
    {
        if(!context.Players.Any())
        {
            for(int i = 0; i < 10; i++)
            {
                context.Players.Add(new Player()
                {
                    Name = "Guest " + i,
                    GameCount = 1,
                    AverageGuesses = 6,
                    AverageSecondsPerGame = 600
                });
            }
        }
    }
}