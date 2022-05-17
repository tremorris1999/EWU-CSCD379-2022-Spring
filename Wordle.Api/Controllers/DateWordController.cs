using Microsoft.AspNetCore.Mvc;

namespace Wordle.Api.Controllers;
public class DateWordController : Controller
{
    [HttpGet]
    public string GetDailyWord(DateTime date)
    {
        
        return "Zebra";
    }
}

