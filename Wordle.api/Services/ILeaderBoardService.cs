namespace Wordle.api.Services
{
    public interface ILeaderBoardService
    {
        IEnumerable<Score> GetScores();
        void AddScore(GameScore score);
    }
}
