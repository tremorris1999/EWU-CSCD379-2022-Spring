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

    [TestMethod]
    public void Constructor_Success()
    {
        PlayerService subject = new(context!);
        Assert.IsNotNull(subject);
    }

    [TestMethod]
    public void Get_ReturnsList_Success()
    {

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
        /*

        */
    }
}