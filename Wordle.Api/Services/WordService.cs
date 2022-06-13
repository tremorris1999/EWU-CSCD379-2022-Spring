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

    public bool AddWord(string value, bool common)
    {
        bool added = _context.Words.FirstOrDefault(item => item.Value.CompareTo(value) == 0) == null ? true : false;
        if(added)
        {
            _context.Words.Add(new Word {
                Value = value
            });

            _context.SaveChanges();
        }

        return added;
    }
}