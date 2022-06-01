using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Tests
{
    [TestClass]
    public class GameServiceTests : DatabaseBaseTests
    {
        [TestMethod]
        public void CreateGame_AddsNewGame()
        {
            PlayersService.Seed(context);
            Word.SeedWords(context);
            GameService gameService = new GameService(context);
            PlayersService playerService = new PlayersService(context);

            Player newPlayer = playerService.GetPlayer(1);
            Assert.IsNotNull(newPlayer);

            DateTime now = DateTime.Now;

            int gamesInDb = context.Games.Count();
            Game newGame = gameService.CreateGame(newPlayer, Game.GameTypeEnum.Random, now);
            Assert.AreNotEqual(gamesInDb, context.Games.Count());
            Assert.IsNotNull(newGame);


            //Game game = gameService.GetGame(newPlayer, Game.GameTypeEnum.Random, now);
            //Assert.IsNotNull(game);
            //Assert.AreEqual(playerGuid, game.Player.Guid);
            //Assert.AreEqual(5, game.Word.Value.Length);
        }

        [TestMethod]
        public void GetGame_GetsIncompleteGame()
        {
            PlayersService.Seed(context);
            Word.SeedWords(context);
            GameService gameService = new GameService(context);
            PlayersService playerService = new PlayersService(context);

            Player newPlayer = playerService.GetPlayer(1);

            DateTime now = DateTime.Now;

            Game? newGame = gameService.CreateGame(newPlayer, Game.GameTypeEnum.Random, now);

            Game? game = gameService.GetGame(newGame.GameId);
            Assert.IsNotNull(game);
            Assert.IsNull(game.DateEnded);
        }
        [TestMethod]
        public void FinishGame_FillsDateEnded()
        {
            PlayersService.Seed(context);
            Word.SeedWords(context);
            GameService gameService = new GameService(context);
            PlayersService playerService = new PlayersService(context);

            Player newPlayer = playerService.GetPlayer(1);

            DateTime now = DateTime.Now;

            Game? newGame = gameService.CreateGame(newPlayer, Game.GameTypeEnum.Random, now);

            Game? game = gameService.GetGame(newGame.GameId);

            gameService.FinishGame(game.GameId);

            Assert.IsNotNull(game.DateEnded);
        }
    }
}
