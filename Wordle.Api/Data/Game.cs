using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Wordle.Api.Data;

public class Game
{
    public int GameId { get; set; }
    public int PlayerId { get; set; }
    public Player Player { get; set; } = null!;
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

    }
}
