using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Tests;

[TestClass]
public class PlayerServiceTests : DatabaseBaseTests
{
    [TestMethod]
    public void GetPlayers_MatchesPlayerCount_Success()
    {
        using var context = new TestAppDbContext(Options);
        PlayersService sut = new(context);
        int playerCount = sut.GetPlayers().Count();
        Assert.AreEqual(playerCount, sut.GetPlayers().Count());
    }

    [TestMethod]
    public void GetTop10Player_CountMatchesTen_Success()
    {
        using var context = new TestAppDbContext(Options);
        PlayersService sut = new(context);
        // Add 20 players and their games.
        for (int x = 0; x < 20; x++)
        {
            sut.Update($"Player {x}", (x % 5) +1, x);
        }
        Assert.AreEqual(10, sut.GetTop10Players().Count());
    }

}
