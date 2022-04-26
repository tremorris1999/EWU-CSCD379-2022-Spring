using Wordle.Api.Data;

namespace Wordle.Api.Services
{
    public class ScoreStatsService
    {
        public ScoreStatsService(AppDbContext context)
        {
            _context = context;

        }

        private AppDbContext _context;

        public IEnumerable<ScoreStat> GetScoreStats()
        {
            var result = _context.ScoreStats.OrderBy(x => x.Score);
            return result;
        }

        public static void Seed(AppDbContext context)
        {
            if (!context.ScoreStats.Any())
            {
                for (int i = 1; i <= 6; i++)
                {
                    context.ScoreStats.Add(new ScoreStat()
                    {
                        Score = i,
                        AverageSeconds = 0,
                        TotalGames = 0
                    });
                    
                }
                context.SaveChanges();
            }
        }
    }
}
