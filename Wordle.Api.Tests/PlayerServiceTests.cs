using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
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