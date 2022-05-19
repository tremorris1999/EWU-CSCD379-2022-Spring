using System.ComponentModel.DataAnnotations;

namespace Wordle.Api.Data;

public class Player
{
    public int PlayerId { get; set; }
    public string? Name { get; set; } = null;
    public IList<Game> Games { get; set; } = null!;
    public Guid Guid { get; set; }
}
