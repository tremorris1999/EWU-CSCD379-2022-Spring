using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordle.Api.Controllers;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Tests;
[TestClass]
public class DailyWordTests : DatabaseBaseTests
{
    [TestMethod]
    public void Constructor_Constructs()
    {
        DateWordService Wotd = new(context!);
        Assert.IsNotNull(Wotd);
    }

    [TestMethod]
    public void Get_FindsEntry()
    {
        DateTime thisTime = DateTime.Now;
        DateWord dateWord = new();
        Word newWord = new();

        newWord.Common = true;
        newWord.WordId = 1;
        newWord.Value = "power";

        dateWord.AverageSeconds = 77;
        dateWord.DateWordId = 1;
        dateWord.Word = newWord;
        dateWord.Date = thisTime;
        dateWord.AverageGuesses = 4;
        dateWord.Plays = 5;

        context!.Words.Add(newWord);
        context.DateWords.Add(dateWord);

        context.SaveChanges();
        DateWordService Wotd = new(context!);
        //Wotd.Update(thisTime, 4, 76);
        DateWord? getRequest = Wotd.Get(thisTime);
        Assert.IsNotNull(getRequest);
        Assert.AreEqual("power", getRequest.Word.Value);
        Assert.AreEqual(4, getRequest.AverageGuesses);
        Assert.AreEqual(5, getRequest.Plays);
    }

    [TestMethod]
    public void Update_CorrectlyUpdatesStatistics()
    {
        DateTime thisTime = DateTime.Now;
        DateWord dateWord = new();
        Word newWord = new();

        newWord.Common = true;
        newWord.WordId = 2;
        newWord.Value = "hotel";

        dateWord.AverageSeconds = 5;
        dateWord.DateWordId = 2;
        dateWord.Word = newWord;
        dateWord.Date = thisTime;
        dateWord.AverageGuesses = 1;
        dateWord.Plays = 1;

        context!.Words.Add(newWord);
        context.DateWords.Add(dateWord);

        context.SaveChanges();
        DateWordService Wotd = new(context!);
        Wotd.Update(thisTime, 4, 112);
        DateWord? getRequest= Wotd.Get(thisTime);

        double newAverageGuesses = ((double)(1) + 4) / 2;
        int newAverageSeconds = (5 + 112) / 2;

        Assert.IsNotNull(getRequest);
        Assert.AreEqual(2, getRequest.Plays);
        Assert.AreEqual(newAverageGuesses, getRequest.AverageGuesses);
        Assert.AreEqual(newAverageSeconds, getRequest.AverageSeconds);
    }

    //[TestMethod]
    //public void GetDailyGameNoDateFails()
    //{
    //    using var context = new TestAppDbContext(Options);
    //    Word.SeedWords(context);
    //    var sut = new GameService(context);

    //    Guid playerGuid = Guid.NewGuid();
    //    //Assert.ThrowsException<ArgumentException>(() => 
    //        //sut.CreateGame(playerGuid, Game.GameTypeEnum.WordOfTheDay)
    //    //);

    //}

    [Ignore("Needs a bit more work to get the same game to come back.")]
    [TestMethod]
    public void GetDailyGameThatIsFinished()
    {
        using var context = new TestAppDbContext(Options);
        Word.SeedWords(context);
        var sut = new GameService(context);

        Guid playerGuid = Guid.NewGuid();
        //Game? game1 = sut.CreateGame(playerGuid, Game.GameTypeEnum.WordOfTheDay, new DateTime(2020, 1, 1));
        //sut.FinishGame(game1.GameId);
        //Game? game2 = sut.CreateGame(playerGuid, Game.GameTypeEnum.WordOfTheDay, new DateTime(2020, 1, 1));
        //Assert.AreEqual(game1.GameId, game2.GameId);
        //Assert.IsNotNull(game2.Word.Value);
        //Assert.IsNotNull(game2.DateEnded);
    }


}
