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

    public DateWord? GetDateWord(DateTime sanitizedDate)
    {
        return _context.DateWords
            .Include(item => item.Word)
            .FirstOrDefault(item => item.Date == sanitizedDate);
    }

    public void AddDateWord(DateWord dateword)
    {
        _context.DateWords.Add(dateword);
        _context.SaveChanges();
    }
}