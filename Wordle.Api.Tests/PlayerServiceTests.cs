using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Tests;
[TestClass]
public class PlayerServiceTests
{
    [TestMethod]
    public void MyTestMethod()
    {
        var contextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Wordle.Api.Tests;Trusted_Connection=True;MultipleActiveResultSets=true");
        var context = new AppDbContext(contextOptions.Options);
        context.Database.Migrate();
        PlayerService.Seed(context);
        PlayerService sut = new PlayerService(context);

        Assert.AreEqual(12, sut.GetPlayers().Count());
    }

}
