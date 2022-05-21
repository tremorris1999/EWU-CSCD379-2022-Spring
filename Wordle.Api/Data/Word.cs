using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Wordle.Api.Data;

public class Word
{
    public int WordId { get; set; }
    public string Value { get; set; } = null!;
    public bool Common { get; set; }

    public static void SeedWords(AppDbContext context, string filename = "Words.csv")
    {
        const string wordListVersion = "1"; // Increment this to force the file to read again on startup

        var currentVersion = Setting.GetSetting("WordListVersion", context);
        if (wordListVersion != currentVersion)
        {
            // Read the file and update the database
            var wordLines = System.IO.File.ReadAllLines($"Content\\{filename}");

            // Load all current words
            var words = context.Words.ToDictionary(f=>f.Value);

            foreach (var wordLine in wordLines)
            {
                var parts = wordLine.Split(",");
                if (parts.Length == 2)
                {
                    if (!words.ContainsKey(parts[0]))
                    {
                        context.Words.Add(new Word { Value = parts[0], Common = parts[1] == "TRUE" });
                    }
                }
            }
            context.SaveChanges();

            Setting.SetSetting("WordListVersion", wordListVersion, context);            
        }
    }
}

