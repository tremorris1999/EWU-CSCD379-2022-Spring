using Wordle.Api.Data;
public class FinishedGameDto
{
    public int GameId { get; set; }
    public int Guesses { get; set; }
    public int Seconds { get; set; }
    public DateTime Date { get; set; }
    public Game.GameTypeEnum Type { get; set; }
    
}