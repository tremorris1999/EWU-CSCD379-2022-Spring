using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
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