using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Wordle.Api.Data;

public class Game
{
    public int GameId { get; set; }
    public IList<Player> Players { get; set; } = null!;
    public int WordId { get; set; }
    public Word Word { get; set; } = null!;
    public DateTime DateStarted { get; set; }
    public DateTime? DateEnded { get; set; }
    public IList<Guess> Guesses { get; set; } = null!;
}

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasData(new Game { GameId = 1, WordId = 1 });
        builder.HasData(new Game { GameId = 2, WordId = 2 });
        builder.HasData(new Game { GameId = 3, WordId = 3 });
    }
}
