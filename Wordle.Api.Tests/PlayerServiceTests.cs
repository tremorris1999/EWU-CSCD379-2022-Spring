using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using System;
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
        var contextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(new SqliteConnection("DataSource=:memory:"))
            .Options;
        context = new AppDbContext(contextOptions);
        context.Database.Migrate();
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
        
    }

    [TestMethod]

    public void Update_UpdatesExisting_Success()
    {
        
    }
}

/*
using Wordle.Api.Data;

namespace Wordle.Api.Services;

public class PlayerService
{
    private AppDbContext _context;
    public PlayerService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Player> GetPlayers()
    {
            return _context.Players
                .AsEnumerable()
                .OrderBy(item => item.AverageGuesses);
    }

    public void Update(string name, int guesses, int seconds)
    {
        if(guesses < 1 || guesses > 6){
            throw new ArgumentOutOfRangeException("Guesses must be between 1 and 6");
        }
        if(seconds < 1)
        {
            throw new ArgumentOutOfRangeException("Seconds must be greater than 0");
        }
        
        Player? player = _context.Players.FirstOrDefault(item => item.Name!.CompareTo(name) == 0);
        if (player != null)
        {
            double aggregateGuesses = (player.AverageGuesses * player.GameCount) + guesses;
            int aggregateSeconds = (player.AverageSecondsPerGame * player.GameCount) + seconds;
            player.GameCount += 1;
            player.AverageGuesses = aggregateGuesses / player.GameCount;
            player.AverageSecondsPerGame = aggregateSeconds / player.GameCount;
        }
        else
            _context.Players.Add(new Player()
            {
                Name = name,
                GameCount = 1,
                AverageGuesses = guesses,
                AverageSecondsPerGame = seconds
            });
        
        _context.SaveChanges();
    }
}
*/