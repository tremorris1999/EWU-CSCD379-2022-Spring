using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WordController : Controller
{
    private readonly WordService _service;

    public WordController(WordService service)
    {
        _service = service;
    }

    [HttpGet]
    public String Get()
    {
        return _service.GetWord().Value?? "boned";
    }

    /**
    * We can use this to verify if a word is in our words db table.
    * Not useful... YET!
    */
    [HttpPost]
    public IActionResult Post(string word)
    {
        if(_service.Contains(word) != null)
        {
            return Ok("Found");
        }

        return NotFound();
    }
}
