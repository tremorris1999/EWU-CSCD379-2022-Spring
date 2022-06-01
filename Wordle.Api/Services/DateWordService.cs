using Wordle.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Wordle.Api.Services;

public class DateWordService
{
    private AppDbContext _context;
    public DateWordService(AppDbContext context)
    {
        _context = context;
    }

    public DateWord? Get(DateTime date)
    {
        return _context.DateWords.FirstOrDefault(item => item.Date == date);
    }

    public void Update(DateTime date, int guesses, int seconds)
    {
        DateWord? dateWord = _context.DateWords.FirstOrDefault(item => item.Date == date);
        if(dateWord is null)
            return;

        double aggregateGuesses = dateWord.AverageGuesses * dateWord.Plays + guesses;
        int aggregateSeconds = dateWord.AverageSeconds * dateWord.Plays + seconds;
        dateWord.Plays += 1;
        dateWord.AverageGuesses = aggregateGuesses / (double)dateWord.Plays;
        dateWord.AverageSeconds = aggregateSeconds / dateWord.Plays;
        
        _context.SaveChanges();
    }
}