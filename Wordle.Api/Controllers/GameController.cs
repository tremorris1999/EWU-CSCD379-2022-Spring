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
    private DateWordService _dateWordService;

    public GameController(AppDbContext context, GameService gameService, PlayersService playersService, DateWordService dateWordService)
    {
        _context = context;
        _gameService = gameService;
        _playersService = playersService;
        _dateWordService = dateWordService;
    }

    [HttpGet]
    public GameDto Get(DateTime dateTime, string name, bool random)
    {
        Player? p = _playersService.GetPlayer(name) ?? new Player{ Name = name };
        Game g;
        DateWord? dateWord;
        if(random)
        {
            g = _gameService.CreateGame(p, Game.GameTypeEnum.Random, DateTime.Now);
            dateWord = null;
        }
        else // WOTD
        {
            g = _gameService.GetGame(p, Game.GameTypeEnum.WordOfTheDay, dateTime.Date) ?? _gameService.CreateGame(p, Game.GameTypeEnum.WordOfTheDay, dateTime.Date);
            dateWord = _dateWordService.Get(dateTime.Date);
        }

        _context.SaveChanges();
        return dateWord == null ? new GameDto(g) : new GameDto(g, dateWord);
    }

    [Route("last-ten")]
    [HttpGet]
    public IEnumerable<GameDto> GetLastTen(string playerName)
    {
        List<GameDto> games = new();
        for(int i = 0; i < 10; i++)
        {
            games.Add(Get(System.DateTime.Now.Date.AddDays(-1 * i), playerName, false));
        }

        return games;
    }

    [HttpPut]
    public IActionResult UpdateGame([FromBody] FinishedGameDto dto)
    {
        Game game = _gameService.FinishGame(dto.GameId);
        Player? p = _playersService.GetPlayer(game.PlayerId);
        if(p is null)
            throw new BadHttpRequestException("Player does not exist", 500);
        if(p.Name is null)
            throw new BadHttpRequestException("Player.Name does not exist", 500);

        _playersService.Update(p.Name, dto.Guesses, dto.Seconds);
        if(dto.Type == Game.GameTypeEnum.WordOfTheDay)
            _dateWordService.Update(dto.Date.Date, dto.Guesses, dto.Seconds);

        return Ok();
    }

    [Route("change-player")]
    [HttpPut]
    public void ChangePlayer([FromBody]int gameId, string name)
    {
        Game game = _gameService.GetGame(gameId) ?? throw new BadHttpRequestException("Game does not exist", 500);
        Player? player = _playersService.GetPlayer(name);
        if(player is null)
        {
            player = new Player(){ Name = name };
            _context.Players.Add(player);
        }

        game.PlayerId = player.PlayerId;
        _context.SaveChanges();
    }
}