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

    public Player? Get(string name)
    {
        return _context.Players
            .FirstOrDefault(item => item.Name.CompareTo(name) == 0);
    }

    public void Update(string name, int guesses, int seconds)
    {
        if(guesses < 1 || guesses > 6){
            throw new ArgumentOutOfRangeException("Guesses must be between 1 and 6");
        }
        if(seconds < 1)
        {
            throw new ArgumentOutOfRangeException("Seconds must be greater than 0");
        }
        
        Player? player = Get(name);
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
}
