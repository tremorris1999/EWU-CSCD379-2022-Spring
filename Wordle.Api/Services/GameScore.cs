namespace Wordle.Api.Services
{
    public class GameScore
    {
        public int Score { get; set; }
        public string Name { get; set; }

        public GameScore(int score, string name)
        {
            Score = score;
            Name = name;
        }
    }
}
