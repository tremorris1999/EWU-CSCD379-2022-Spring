namespace Wordle.Api.Services
{
    public interface ILeaderBoardService
    {
        IEnumerable<Score> GetScores();
        void AddScore(GameScore score);
    }
}
