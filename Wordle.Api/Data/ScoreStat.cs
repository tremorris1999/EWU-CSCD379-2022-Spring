using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Wordle.Api.Data
{
    public class ScoreStat
    {
        [Key]
        public int ScoreStatId { get; set; }
        public int Score { get; set; }
        public int AverageSeconds { get; set; }
        public int TotalGames { get; set; }

        public ScoreStat Clone()
        {
            return new ScoreStat
            {
                ScoreStatId = ScoreStatId,
                Score = Score,
                AverageSeconds = AverageSeconds,
                TotalGames = TotalGames,

            };
        }
    }

    public class ScoreStatConfiguration : IEntityTypeConfiguration<ScoreStat>
    {
        public void Configure(EntityTypeBuilder<ScoreStat> builder)
        {
            builder.HasData(new ScoreStat { ScoreStatId = 1, Score = 1, AverageSeconds = 0, TotalGames = 0 });
            builder.HasData(new ScoreStat { ScoreStatId = 2, Score = 2, AverageSeconds = 0, TotalGames = 0 });
            builder.HasData(new ScoreStat { ScoreStatId = 3, Score = 3, AverageSeconds = 0, TotalGames = 0 });
            builder.HasData(new ScoreStat { ScoreStatId = 4, Score = 4, AverageSeconds = 0, TotalGames = 0 });
            builder.HasData(new ScoreStat { ScoreStatId = 5, Score = 5, AverageSeconds = 0, TotalGames = 0 });
            builder.HasData(new ScoreStat { ScoreStatId = 6, Score = 6, AverageSeconds = 0, TotalGames = 0 });
        }
    }
}
