using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PlayerController : ControllerBase
{
    public class PlayerPost
    {
        public string Name { get; set; } = "Anonymous";
        public int Guesses { get; set; }
        public int Seconds { get; set; }
    }

    private readonly PlayerService _service;
    public PlayerController(PlayerService service)
    {
        _service = service;
    }

    [HttpGet]
    public IEnumerable<Player> Get()
    {
        return _service.GetPlayers()
            .ToList()
            .GetRange(0, 10);
    }

    [HttpPost]
    public IActionResult Post([FromBody] PlayerPost player)
    {
        _service.Update(player.Name, player.Guesses, player.Seconds);
        return Ok();
    }
}
