
namespace Wordle.Api.Data;

public class Game
{
    public int GameId { get; set; }
    public IEnumerable<Player> Players { get; set; } = null!;
    public DateTime Date { get; set; }
    public int Plays { get; set; }
    public double AverageGuesses { get; set; }
    public int AverageSeconds { get; set; }
}