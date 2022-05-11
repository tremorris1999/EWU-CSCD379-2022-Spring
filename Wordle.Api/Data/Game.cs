namespace Wordle.Api.Data;

public class Game
{
    public int GameId { get; set; }
    public int PlayerId { get; set; }
    public int WordId { get; set; }
    public Word Word { get; set; }
}
