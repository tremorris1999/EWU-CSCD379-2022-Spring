using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DateWordController : Controller
{
    private readonly AppDbContext _context;
    private readonly GameService _gameService;
    private readonly static object _mutex = new();
    private static readonly ConcurrentDictionary<DateTime, string> _cache = new();

    public DateWordController(AppDbContext context, GameService gameService)
    {
        _context = context;
        _gameService = gameService;
    }

    [HttpGet]
    public string? GetDailyWord(DateTime date)
    {
        //Sanitize the date by dropping time data
        date = date.Date;
        if (date.ToUniversalTime() >= System.DateTime.Today.ToUniversalTime().AddDays(0.5))
        {
            return null;
        }
        //Check if the day has a word in the database
        if (_cache.TryGetValue(date, out var word))
        {
            return word;
        }
        DateWord? wordOfTheDay = _context.DateWords
            .Include(x => x.Word)
            .FirstOrDefault(dw => dw.Date == date);

        if (wordOfTheDay != null)
        //Yes: return the word
        {
            _cache.TryAdd(date, wordOfTheDay.Word.Value);
            return wordOfTheDay.Word.Value;
        }
        else
        {
            //Mutex magic
            lock (_mutex)
            {
                wordOfTheDay = _context.DateWords
                    .Include(x => x.Word)
                    .FirstOrDefault(dw => dw.Date == date);
                if (wordOfTheDay != null)
                //Yes: return the word
                {
                    return wordOfTheDay.Word.Value;
                }
                else
                {
                    //No: get a random word from our list
                    var chosenWord = _gameService.GetWord();
                    //Save the word to the database with the date
                    _context.DateWords.Add(new DateWord { Date = date, Word = chosenWord });
                    _context.SaveChanges();
                    //Return the word
                    _cache.TryAdd(date, chosenWord.Value);
                    return chosenWord.Value;
                }
            }
        }
    }
}

internal record struct NewStruct(object Item1, object Item2)
{
    public static implicit operator (object, object)(NewStruct value)
    {
        return (value.Item1, value.Item2);
    }

    public static implicit operator NewStruct((object, object) value)
    {
        return new NewStruct(value.Item1, value.Item2);
    }
}