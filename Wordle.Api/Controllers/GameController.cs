using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GameController : ControllerBase
{
    private AppDbContext _context;
    private GameService _gameService;
    private PlayersService _playersService;

    public GameController(AppDbContext context, GameService gameService, PlayersService playersService)
    {
        _context = context;
        _gameService = gameService;
        _playersService = playersService;
    }

    [HttpGet]
    public GameDto Get(DateTime dateTime, string name)
    {
        Player? p = _playersService.GetPlayer(name) ?? new Player{ Name = name };
        Game g = _gameService.GetGame(p, Game.GameTypeEnum.WordOfTheDay, dateTime) ?? _gameService.CreateGame(p, Game.GameTypeEnum.WordOfTheDay, dateTime);
        _context.SaveChanges();
        return new GameDto(g);
    }
}