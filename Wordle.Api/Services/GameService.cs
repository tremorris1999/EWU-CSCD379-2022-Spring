 using Wordle.Api.Data;

 namespace Wordle.Api.Services;

 public class GameService
 {
     private AppDbContext _context;
     private PlayerService _playerService;

     public GameService(AppDbContext context, PlayerService playerService)
     {
        _context = context;
        _playerService = playerService;
     }

     public Game? GetGame(DateTime dateTime)
     {
         return _context.Games
            .FirstOrDefault(item => item.Date.Date == dateTime.Date);
     }

     public void UpdateGame(DateTime dateTime, string playerName, int guesses, int seconds)
     {
         _playerService.Update(playerName, guesses, seconds);
         Player player = _playerService.Get(playerName)!; // Bang operator because line 24 ensures player is not null.

         Game? game = GetGame(dateTime);
         if(game != null)
         {
             double aggregateGuesses = (game.AverageGuesses * game.Plays) + guesses;
             int aggregateSeconds = (game.AverageSeconds * game.Plays) + seconds;
             
             game.Plays += 1;
             game.AverageGuesses = aggregateGuesses / game.Plays;
             game.AverageSeconds = aggregateSeconds / game.Plays;
             game.Players.ToList().Add(player);
         }
         else
         {
             game = new Game(){
                 Date = dateTime,
                 AverageGuesses = guesses,
                 AverageSeconds = seconds,
                 Players = new List<Player>() { player },
                 Plays = 1
             };

             _context.Games.Add(game);
         }

        _context.SaveChanges();
     }
 }