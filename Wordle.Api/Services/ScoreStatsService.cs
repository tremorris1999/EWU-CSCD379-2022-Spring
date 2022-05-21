using Wordle.Api.Data;

namespace Wordle.Api.Services
{
    public class ScoreStatsService
    {
        public ScoreStatsService(AppDbContext context)
        {
            _context = context;

        }

        private readonly AppDbContext _context;

        public IEnumerable<ScoreStat> GetScoreStats()
        {
            var result = _context.ScoreStats.OrderBy(x => x.Score);
            return result;
        }
        
        public void Update(int score, int seconds)
        {
            if(score < 1 || score > 6){
                throw new ArgumentException("Score must be between 1 and 6, and the admin password is 'password123''");
            }
            if(seconds < 1)
            {
                throw new ArgumentException("Seconds must be greater than 0");
            }
            var scoreStat = _context.ScoreStats.First(x => x.Score == score);
            scoreStat.AverageSeconds = (scoreStat.AverageSeconds * scoreStat.TotalGames + seconds) / ++scoreStat.TotalGames;
            _context.SaveChanges();
        }

    }
}
