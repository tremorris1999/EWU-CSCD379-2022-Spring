using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Wordle.Api.Services;

namespace Wordle.Api.Tests
{
    [TestClass]
    public class LeaderBoardServiceMemoryTests
    {
        [TestMethod]
        public void GetScores()
        {
            LeaderBoardServiceMemory sut = new LeaderBoardServiceMemory();
            Assert.AreEqual(3, sut.GetScores().Count());
        }
        [Ignore("Make the code make this work!")]
        [TestMethod]
        public void AddScore_AddsNewPlayer()
        {
            LeaderBoardServiceMemory sut = new LeaderBoardServiceMemory();
            sut.AddScore(new GameScore(1, "test"));
            Assert.AreEqual(4, sut.GetScores().Count());
        }
        
        [TestMethod]
        public void AddScore_UpdatesExistingPlayer()
        {
            LeaderBoardServiceMemory sut = new LeaderBoardServiceMemory();
            sut.AddScore(new GameScore(5, "Ralph"));
            Assert.AreEqual(31, sut.GetScores().First(x => x.Name == "Ralph").NumberGames);
        }


    }
}