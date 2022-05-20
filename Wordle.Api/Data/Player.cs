using System.ComponentModel.DataAnnotations;

namespace Wordle.Api.Data;

public class Player
{
    [Key]
    public int PlayerId { get; set; }
    public string? Name { get; set; }
    public int GameCount { get; set; }
    public double AverageAttempts { get; set; }
    public int AverageSecondsPerGame { get; set; }
    public IList<Game> Games { get; set; } = null!;
    public Guid Guid { get; set; }

    public Player Clone()
    {
        return new Player
        {
            PlayerId = PlayerId,
            Name = Name,
            GameCount = GameCount,
            AverageAttempts = AverageAttempts,
            AverageSecondsPerGame = AverageSecondsPerGame,
        };
    }

}
