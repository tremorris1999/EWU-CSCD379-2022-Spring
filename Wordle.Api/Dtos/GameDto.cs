using Wordle.Api.Data;

namespace Wordle.Api.Dtos
{
    public class GameDto
    {
        public string Word { get; set; }
        public DateTime Date { get; set; }
        public int GameId { get; set; }
        public bool WasPlayed { get; set; }
        public double AverageGuesses { get; set; }
        public int AverageSeconds { get; set; }

        public GameDto(Game game)
        {
            Word = game.Word;
            Date = game.DateStarted;
            GameId = game.GameId;
            WasPlayed = game.DateEnded.HasValue;
        }

        public GameDto(Game game, DateWord dateWord)
        {
            Word = game.Word;
            Date = game.DateStarted;
            GameId = game.GameId;
            WasPlayed = game.DateEnded.HasValue;
            AverageGuesses = dateWord.AverageGuesses;
            AverageSeconds = dateWord.AverageSeconds;
        }
    }
}
