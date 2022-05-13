using Microsoft.EntityFrameworkCore;
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
    public class ScoreStatsServiceTests : DatabaseBaseTests
    {
        [TestMethod]
        public void GetScoreStats()
        {
            using var context = new TestAppDbContext(Options);
            ScoreStatsService sut = new ScoreStatsService(context);

            Assert.AreEqual(6, sut.GetScoreStats().Count());
        }

        [TestMethod]
        public void CalculateAverageSeconds()
        {
            using var context = new TestAppDbContext(Options);
            ScoreStatsService sut = new ScoreStatsService(context);
            ScoreStat scoreStat1 = sut.GetScoreStats().First(f => f.Score == 1).Clone();
            
            sut.Update(1,2);
            Assert.AreEqual((scoreStat1.TotalGames+1), sut.GetScoreStats().First(f => f.Score==1).TotalGames);
            //Assert.AreEqual(scoreStat1.AverageSeconds+(scoreStat1.AverageSeconds-2)/(scoreStat1.TotalGames+1), sut.GetScoreStats().First(f => f.Score == 1).AverageSeconds);

            ScoreStat scoreStat2 = sut.GetScoreStats().First(f => f.Score == 1).Clone();
            sut.Update(1, 4);

            Assert.AreEqual((scoreStat2.TotalGames + 1), sut.GetScoreStats().First(f => f.Score == 1).TotalGames);
            //Assert.AreEqual(scoreStat2.AverageSeconds + (scoreStat2.AverageSeconds - 4) / (scoreStat2.TotalGames + 1), sut.GetScoreStats().First(f => f.Score == 1).AverageSeconds);
        }
    }
}
