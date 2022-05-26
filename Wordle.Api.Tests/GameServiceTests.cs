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
        public void CreateGame()
        {
            using var context = new TestAppDbContext(Options);
            var service = new GameService(context);
            Word.SeedWords(context);

            Guid playerGuid = Guid.NewGuid();
            var game = service.CreateGame(playerGuid, Game.GameTypeEnum.Random);

            Assert.IsNotNull(game);
            Assert.AreEqual(playerGuid, game.Player.Guid);
            Assert.AreEqual(5, game.Word.Value.Length);
        }
        [TestMethod]
        public void Guess()
        {
            Guid playerGuid = Guid.NewGuid();
            Game game;
            
            using (var context = new TestAppDbContext(Options))
            {
                var service = new GameService(context);
                Word.SeedWords(context);

                game = service.CreateGame(playerGuid, Game.GameTypeEnum.Random);
            }
            
            using (var context = new TestAppDbContext(Options))
            {
                var service = new GameService(context);
                var result = service.SubmitGuess("zzzzz", DateTimeOffset.Now, game.GameId, playerGuid);

                Assert.IsFalse(result);
            }

        }
    }
}
