namespace Wordle.Api.Data;

public class Guess
{
    public int GuessId { get; set; }
    public int GameId { get; set; }
    public Game Game { get; set; } = null!;
    public string Value { get; set; } = null!;
    public DateTime Date { get; set; }
}
