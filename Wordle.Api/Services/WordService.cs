using Wordle.Api.Data;

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
        return _context.Words.Select(item => item.Value).OrderBy(item => item);   
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

    public bool ChangeCommon(string value, bool common)
    {
        Word? word = _context.Words.FirstOrDefault(item => item.Value.CompareTo(value) == 0);
        if(word is not null)
        {
            word.Common = common;
            _context.SaveChanges();
            return true;
        }

        return false;
    }

    public bool RemoveWord(string value)
    {
        Word? word = _context.Words.FirstOrDefault(item => item.Value.CompareTo(value) == 0);
        if(word is not null)
        {
            _context.Remove<Word>(word);
            _context.SaveChanges();
            return true;
        }

        return false;
    }
}