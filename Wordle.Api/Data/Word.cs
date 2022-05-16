using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Wordle.Api.Data;

public class Word
{
    public int WordId { get; set; }
    public string Value { get; set; } = null!;
}

public class WordConfiguration : IEntityTypeConfiguration<Word>
{
    public void Configure(EntityTypeBuilder<Word> builder)
    {
        builder.HasData(new Word { WordId = 1, Value = "thing" });
        builder.HasData(new Word { WordId = 2, Value = "think" });
        builder.HasData(new Word { WordId = 3, Value = "thong" });
        builder.HasData(new Word { WordId = 4, Value = "throb" });
        builder.HasData(new Word { WordId = 5, Value = "thunk" });
        builder.HasData(new Word { WordId = 6, Value = "wrong" });
    }
}    
