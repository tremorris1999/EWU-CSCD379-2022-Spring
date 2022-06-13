using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Dtos;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WordController : Controller
{
    private readonly WordService _wordService;

    public WordController(WordService wordService)
    {
        _wordService = wordService;
    }

    [HttpGet]
    [Route("[action]")]
    public IEnumerable<String> Get()
    {
        return _wordService.GetWords();
    }

    [HttpPost]
    [Route("[action]")]
    public IActionResult Add([FromBody]PostWord word)
    {
        return _wordService.AddWord(word.Value, word.Common) ? Ok() : Conflict();
    }
}

public class PostWord
{
    public string Value { get; set; } = null!;
    public bool Common { get; set; }
}