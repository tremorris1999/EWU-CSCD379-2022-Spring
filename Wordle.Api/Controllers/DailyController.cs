using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Services;
using System.Collections.Concurrent;

namespace Wordle.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DailyController : Controller
{
    private readonly WordService _wordService;
    private readonly DateWordService _dateWordService;
    private static readonly ConcurrentDictionary<DateTime, string> _cache = new();
    private static readonly object _mutex = new();

    public DailyController(WordService wordService, DateWordService dateWordService)
    {
        _wordService = wordService;
        _dateWordService = dateWordService;
    }

    [HttpGet]
    public string? Get(DateTime date)
    {
        date = date.Date;
        if(date.ToUniversalTime() >= System.DateTime.Today.ToUniversalTime().AddDays(0.5))
            return null;

        if(_cache.TryGetValue(date, out var word))
            return word;

        DateWord? wordOfTheDay = _dateWordService.GetDateWord(date);
        if(wordOfTheDay != null)
        {
            _cache.TryAdd(date, wordOfTheDay.Word.Value);
            return wordOfTheDay.Word.Value;
        }

        lock (_mutex)
        {
            Word randomWord = _wordService.GetWord();
            _dateWordService.AddDateWord(new DateWord() { Date = date, Word = randomWord });
            _cache.TryAdd(date, randomWord.Value);
            return randomWord.Value;
        }
    }

    [Route("/api/[controller]/last-ten")]
    [HttpGet]
    public IEnumerable<String> GetLastTen()
    {
        List<string> list = new();
        for(int i = 0; i < 10; i++)
        {
            String? word = Get(System.DateTime.Now.AddDays(-1 * i));
            if(word != null)
                list.Add(word);
        }

        return list;

    }
}
