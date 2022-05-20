using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordle.Api.Data;

namespace Wordle.Api.Tests;

[TestClass]
public class DummyTest : DatabaseBaseTests
{
    [TestMethod]
    public async Task DoNothing()
    {
        using var context = new TestAppDbContext(Options);
        Assert.AreEqual(2, await context.Players.CountAsync());
    }


    [TestMethod]
    public async Task CreateObject()
    {
        var player = new Player { Name = "Inigo Montoya" };
        var word = new Word { Value = "Hello" };
        var game = new Game { Word = word };
        player.Games = new List<Game>();
        player.Games.Add(game);


        using var context = new TestAppDbContext(Options);
        context.Players.Add(player);
        await context.SaveChangesAsync();

        using var context2 = new TestAppDbContext(Options);

        Console.WriteLine(context2.Players);
    }

    [TestMethod]
    public void CreateObjectInMultipleContext()
    {
        //var player = new Player { Name = "Inigo Montoya" };
        //var word = new Word { Value = "Hello" };

        //using var context = new TestAppDbContext(Options);
        //context.Players.Add(player);
        //context.Words.Add(word);
        //await context.SaveChangesAsync();

        //using var context2 = new TestAppDbContext(Options);
        ////context2.Games.Add(new Game { PlayerId = player.PlayerId, WordId = word.WordId });
        //await context2.SaveChangesAsync();
    }

    [TestMethod]
    public void RetrievePlayerAndGameInfo()
    {
        //var player = new Player { Name = "Inigo Montoya" };
        //var word = new Word { Value = "Hello" };
        //var word2 = new Word { Value = "World" };

        //using var context = new TestAppDbContext(Options);
        //context.Players.Add(player);
        //context.Words.Add(word);
        //context.Words.Add(word2);
        //await context.SaveChangesAsync();

        //using var context2 = new TestAppDbContext(Options);
        //context2.Games.Add(new Game { PlayerId = player.PlayerId, WordId = word.WordId });
        //context2.Games.Add(new Game { PlayerId = player.PlayerId, WordId = word2.WordId });
        //await context2.SaveChangesAsync();

        //using var context3 = new TestAppDbContext(Options);
        //var fetchedPlayer = await context3.Players
        //    .Include(p => p.Games)
        //        .ThenInclude(g => g.Word).SingleAsync(p => p.PlayerId == player.PlayerId);

        //Assert.AreEqual(2, fetchedPlayer.Games.Count);
        //Assert.IsNotNull(fetchedPlayer.Games[0].Word);
        //Assert.AreEqual("Hello", fetchedPlayer.Games[0].Word.Value);
        //Assert.IsNotNull(fetchedPlayer.Games[1].Word);
        //Assert.AreEqual("World", fetchedPlayer.Games[1].Word.Value);
    }
}
