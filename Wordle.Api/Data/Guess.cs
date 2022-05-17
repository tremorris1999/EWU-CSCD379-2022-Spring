namespace Wordle.Api.Data;

public class Guess
{
    public int GuessId { get; set; }
    public int GameId { get; set; }
    public Game Game { get; set; }
    public string Value { get; set; }
}
