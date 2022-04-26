namespace Wordle.Api.Services
{
    public class LeaderBoardServiceMemory : ILeaderBoardService
    {

        private static readonly List<Score> _scores = new List<Score>();

        public LeaderBoardServiceMemory()
        {
            if (!_scores.Any())
            {
                _scores.Add(new Score("Ralph", 30, 3.4));
                _scores.Add(new Score("Gene", 50, 4.1));
                _scores.Add(new Score("Hildagaurd", 25, 2.6));
            }
        }

        public void AddScore(GameScore gameScore)
        {
            
            var score = _scores.FirstOrDefault(f => f.Name == gameScore.Name);
            if (score is not null)
            {
                score.AverageGuesses = ((score.NumberGames * score.AverageGuesses)
                    + gameScore.Score) / ++score.NumberGames;
            }
        }

        public IEnumerable<Score> GetScores()
        {
            return _scores;
        }
    }
}
