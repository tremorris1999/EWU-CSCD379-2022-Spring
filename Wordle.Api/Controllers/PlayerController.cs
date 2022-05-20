using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlayersController : ControllerBase
{
    private readonly PlayersService _service;

    public PlayersController(PlayersService service)
    {
        _service = service;
    }

    [HttpGet]
    public IEnumerable<Player> Get()
    {
        return _service.GetPlayers();
    }

    [Route("[action]")]
    [HttpGet]
    public IEnumerable<Player> GetTop10()
    {
        return _service.GetTop10Players();
    }

    [HttpPost]
    public IActionResult Post([FromBody] PlayerPost player)
    {
        if (player == null || player.Attempts < 1 || player.Attempts > 6
            || player.Seconds < 1)
        {
            return BadRequest();
        }
        //how is the PlayerPost being created and how to you validate its input?
        _service.Update(player.Name ?? "Guest", player.Attempts, player.Seconds);
        return Ok();
    }

    public class PlayerPost
    {
        public string? Name { get; set; }
        public int Attempts { get; set; }
        public int Seconds { get; set; }
    }
}
