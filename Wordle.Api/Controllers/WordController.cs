using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Services;
using Wordle.Api.Identity;
using Microsoft.AspNetCore.Authorization;

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

    [HttpPut]
    [Route("[action]")]
    [Authorize(Roles=Roles.MOTU)]
    public IActionResult Delete([FromBody]PostWord word)
    {
        return _wordService.RemoveWord(word.Value) ? Ok() : Conflict();
    }

    [HttpPut]
    [Route("[action]")]
    [Authorize]
    public IActionResult ChangeCommon([FromBody]PostWord word)
    {
        return _wordService.ChangeCommon(word.Value, word.Common) ? Ok() : Conflict();
    }

    [HttpPost]
    [Route("[action]")]
    [Authorize(Roles=Roles.MOTU)]
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