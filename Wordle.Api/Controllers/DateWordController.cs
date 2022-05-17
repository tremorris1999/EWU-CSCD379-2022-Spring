using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;

namespace Wordle.Api.Controllers;
public class DateWordController : Controller
{
    private readonly AppDbContext _context;

    public DateWordController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<string?> GetDailyWord(DateTime date)
    {
        //Sanitize the date by dropping time data
        date = date.Date;
        if (date.ToUniversalTime() >= System.DateTime.Today.ToUniversalTime().AddDays(0.5))
        {
            return null;
        }
        //Check if the day has a word in the database
        DateWord? wordOfTheDay = _context.DateWords
            .Include(x => x.Word)
            .FirstOrDefault(dw => dw.Date == date);

        //Mutex magic

        if (wordOfTheDay != null)
        //Yes: return the word
        {
            return wordOfTheDay.Word.Value;
        }
        else
        {
            //No: get a random word from our list
            int wordCount = _context.Words.Count();
            int randomIndex = new Random().Next(0, wordCount);
            Word chosenWord = _context.Words
                .OrderBy(w => w.WordId)
                .Skip(randomIndex)
                .Take(1)
                .First();
            //Save the word to the database with the date
            _context.DateWords.Add(new DateWord { Date = date, Word = chosenWord });
            await _context.SaveChangesAsync();
            //Return the word
            return chosenWord.Value;
        }
    }
}

