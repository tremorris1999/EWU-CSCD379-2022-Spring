using System.ComponentModel.DataAnnotations;

namespace Wordle.Api.Data;

public class Word
{
    [Key]
    public int WordId { get; set; }

    [Required]
    public string? Value { get; set; } = null;
}