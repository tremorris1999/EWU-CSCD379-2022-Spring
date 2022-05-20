using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Tests;

[TestClass]
public class PlayerServiceTests
{
    private readonly AppDbContext _context;

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
        PlayersService sut = new(_context);
        int playerCount = sut.GetPlayers().Count();
        Assert.AreEqual(playerCount, sut.GetPlayers().Count());
    }

    [TestMethod]
    public void GetTop10Player_CountMatchesTen_Success()
    {
        PlayersService sut = new(_context);
        int playerCount = 10;
        Assert.AreEqual(playerCount, sut.GetTop10Players().Count());
    }

}
