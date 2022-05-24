namespace Wordle.Api.Dtos
{
    public class GameDto
    {
        public string Word { get; set; }
        public int GameId { get; set; }

        public GameDto(string word, int gameId)
        {
            Word = word;
            GameId = gameId;
        }
    }
}
