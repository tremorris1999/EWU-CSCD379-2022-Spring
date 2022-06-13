using Wordle.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Wordle.Api.Services;

public class WordService
{
    private AppDbContext _context;
    public WordService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<String> GetWords()
    {
        return _context.Words.Select(item => item.Value);   
    }
}