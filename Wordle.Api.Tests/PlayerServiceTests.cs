using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
<<<<<<< HEAD
using System;
=======
using System.Collections.Generic;
using System.Linq;
>>>>>>> a7092c9 (added update adds new test)
using Wordle.Api.Data;
using Wordle.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

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
        PlayerService subject = new(context!);
        
        
        List<Player> dummyPlayers = new();

        Player SmartyPants = new Player{
            Name = "schuyler", 
            GameCount = 5, 
            AverageGuesses = 2.5, 
            AverageSecondsPerGame = 30};
        
        Player Linh = new Player{
                Name = "Linh", 
                GameCount = 6, 
                AverageGuesses = 2, 
                AverageSecondsPerGame = 20};

        Player Trover = new Player{
            Name = "Trover", 
            GameCount = 35, 
            AverageGuesses = 5.8, 
            AverageSecondsPerGame = 500};
            
        dummyPlayers.Append(Linh);
        dummyPlayers.Append(SmartyPants);
        dummyPlayers.Append(Trover);

        subject.Update(SmartyPants.Name, (int)SmartyPants.AverageGuesses, SmartyPants.AverageSecondsPerGame);
        subject.Update(Trover.Name, (int)Trover.AverageGuesses, Trover.AverageSecondsPerGame);
        subject.Update(Linh.Name, (int)Linh.AverageGuesses, Linh.AverageSecondsPerGame);
        
        IEnumerable<Player> playersLocal = subject.GetPlayers(); 
        

        for (int i = 0; i < playersLocal.Count()-1; i++) {
            Assert.IsTrue(playersLocal.ElementAt(i).AverageGuesses < playersLocal.ElementAt(i+1).AverageGuesses);
        }
        

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

        sut.Update("Test", 1, 1);

        Assert.IsTrue(sut.GetPlayers().ToArray().Length != 0);
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