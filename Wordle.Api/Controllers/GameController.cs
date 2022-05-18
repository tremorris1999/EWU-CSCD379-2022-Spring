using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GameController : ControllerBase
{
    private AppDbContext _context;
    private GameService _gameService;

    public GameController(AppDbContext context, GameService gameService)
    {
        _context = context;
        _gameService = gameService;
    }

    [HttpGet]
    public Game Get(DateTime dateTime)
    {
        return null!; // TODO: implement
    }
}