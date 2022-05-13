using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Tests;

[TestClass]
public class PlayerServiceTests
{
    private AppDbContext? context;

    [TestInitialize]
    public void Setup()
    {
        var db = new SqliteConnection("Data Source=:memory:;");
        db.Open();

        var contextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(db)
            .Options;

        context = new AppDbContext(contextOptions);
        context.Database.EnsureCreated();
    }

    //[TestCleanup]
    //public void closeConnection()
    //{
    //    cont
    //}

    [TestMethod]
    public void Constructor_Success()
    {
        PlayerService subject = new(context!);
        Assert.IsNotNull(subject);
    }

    [TestMethod]
    public void GetPlayers_ReturnList_Success()
    {
        PlayerService subject = new(context!);
        
        IEnumerable<Player> playersLocal = subject.GetPlayers();

        Assert.IsNotNull(playersLocal);
        

    }

    [TestMethod]
    public void Update10Times_ReturnsCorrectSize_Success()
    {
        PlayerService subject = new(context!);
        for (int i = 0; i < 10; i++)
        {
            subject.Update("" + i, 3, 3);
        }

        IEnumerable<Player> playersLocal = subject.GetPlayers();

        Assert.AreEqual(10, playersLocal.Count());

    }

    [TestMethod]
    public void Get_UpdateOutOfOrder_ReturnsOrdered_Success()
    {
        PlayerService subject = new(context!);


        List<Player> dummyPlayers = new();

        subject.Update("Schuyler", 3, 30);
        subject.Update("Trover", 6, 600);
        subject.Update("Linh", 2, 5);

        IEnumerable<Player> playersLocal = subject.GetPlayers();

        Assert.AreEqual("Linh", playersLocal.ToArray()[0].Name);
        Assert.AreEqual("Schuyler", playersLocal.ToArray()[1].Name);
        Assert.AreEqual("Trover", playersLocal.ToArray()[2].Name);

    }

    [TestMethod]

    public void Update_ThrowsArgumentException()
    {
        PlayerService subject = new(context!);
        try 
        {
            subject.Update("name", -1,5); //right name, wrong guess < 1, right seconds 
            subject.Update("name", 7, 6); //right name, wrong guess > 6, right seconds 
            subject.Update("name", 5, -6); //right name, right guess, wrong seconds < 1
        }
        catch(Exception e)
        {
            Assert.IsInstanceOfType(e, typeof(ArgumentOutOfRangeException));
        }

    }

    [TestMethod]
    public void Update_AddsNew_Success()
    {
        PlayerService sut = new(context!);
        List<Player> players = new();
        players.Add(new Player{
            Name = "Test",
            GameCount = 1,
            AverageGuesses = 1,
            AverageSecondsPerGame = 1
        });

        Assert.IsTrue(sut.GetPlayers().ToArray().Length == 0);

        sut.Update("Test", 1, 1);

        Assert.IsTrue(sut.GetPlayers().ToArray().Length != 0);
    }

    [TestMethod]

    public void Update_UpdatesExisting_Success()
    {
        PlayerService sut = new(context!);
        sut.Update("name", 1, 1);
        sut.Update("name", 2, 2);
        Assert.AreEqual("name", sut.GetPlayers().ToArray()[0].Name);
        Assert.AreEqual(1.5, sut.GetPlayers().ToArray()[0].AverageGuesses);
        Assert.AreEqual((int)1.5, sut.GetPlayers().ToArray()[0].AverageSecondsPerGame);
    }
}

