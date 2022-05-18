using System.ComponentModel.DataAnnotations;

namespace Wordle.Api.Data;

public class Player
{
    [Key]
    public int PlayerId {get; set;}

    [Required]
    public string? Name {get; set;} = null;
    public int GameCount{get; set;}
    public double AverageGuesses{get; set;}
    public int AverageSecondsPerGame{get; set;}
}