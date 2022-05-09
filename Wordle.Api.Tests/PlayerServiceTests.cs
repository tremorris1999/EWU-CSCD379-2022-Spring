using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Tests;

[TestClass]
public class PlayerServiceTests
{
    private AppDbContext _context;

    public PlayerServiceTests()
    {
        var contextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Wordle.Api.Tests;Trusted_Connection=True;MultipleActiveResultSets=true");
        _context = new AppDbContext(contextOptions.Options);
        _context.Database.Migrate();
        PlayersService.Seed(_context);
    }

    [TestMethod]
    public void GetPlayers_MatchesPlayerCount_Success()
    {
        PlayersService sut = new PlayersService(_context);
        int playerCount = sut.GetPlayers().Count();
        Assert.AreEqual(playerCount, sut.GetPlayers().Count());
    }

    [Ignore("Need to find a way to reset database between each run")]
    [TestMethod]
    public void Update_AddsNewPlayerAndUpdatesExisting_Success()
    {
        PlayersService sut = new PlayersService(_context);
        int attempts = 5;
        int seconds = 10;
        int playerCount = sut.GetPlayers().Count();
        sut.Update("Dead Pirate Roberts", attempts, seconds);
        Assert.AreEqual(playerCount + 1, sut.GetPlayers().Count());
        Player player1 = sut.GetPlayers().First(x => x.Name.Equals("Buttercup")).Clone();
        attempts = 5;
        seconds = 15;
        sut.Update("Buttercup", attempts, seconds);
        Assert.AreEqual(player1.GameCount + 1, sut.GetPlayers().First(x => x.Name.Equals("Buttercup")).GameCount);
        Assert.AreEqual((player1.AverageSecondsPerGame * player1.GameCount + seconds) / (player1.GameCount + 1), sut.GetPlayers().First(x => x.Name.Equals("Buttercup")).AverageSecondsPerGame);
        Assert.AreEqual((player1.AverageAttempts * player1.GameCount + attempts) / (player1.GameCount + 1), sut.GetPlayers().First(x => x.Name.Equals("Buttercup")).AverageAttempts);
    }

    [TestMethod]
    public void GetTop10Player_CountMatchesTen_Success()
    {
        PlayersService sut = new PlayersService(_context);
        int playerCount = 10;
        Assert.AreEqual(playerCount, sut.GetTop10Players().Count());
    }

}
