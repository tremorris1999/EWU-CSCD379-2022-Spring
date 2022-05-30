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
    public GameDto Get(DateTime dateTime, string name, bool random)
    {
        Player? p = _playersService.GetPlayer(name) ?? new Player{ Name = name };
        Game g;
        if(random)
        {
            g = _gameService.CreateGame(p, Game.GameTypeEnum.Random, DateTime.Now);
        }
        else // WOTD
        {
            g = _gameService.GetGame(p, Game.GameTypeEnum.WordOfTheDay, dateTime) ?? _gameService.CreateGame(p, Game.GameTypeEnum.WordOfTheDay, dateTime);
        }

        _context.SaveChanges();
        return new GameDto(g);
    }

    [HttpPut]
    public void UpdateGame(int gameId, int guesses, int seconds)
    {
        Game game = _gameService.FinishGame(gameId);
        Player? p = _playersService.GetPlayer(game.PlayerId);
        if(p is null)
            throw new BadHttpRequestException("Player does not exist", 500);
        if(p.Name is null)
            throw new BadHttpRequestException("Player.Name does not exist", 500);

        _playersService.Update(p.Name, guesses, seconds);
    }
}