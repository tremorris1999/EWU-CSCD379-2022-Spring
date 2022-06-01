using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordle.Api.Data;

namespace Wordle.Api.Tests;

public abstract class DatabaseBaseTests
{
    public AppDbContext context;
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

    protected SqliteConnection SqliteConnection { get; set; } = null!;
    protected DbContextOptions<AppDbContext> Options { get; private set; } = null!;

    private static ILoggerFactory GetLoggerFactory()
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.AddLogging(builder =>
        {
            builder.AddConsole();
        });
        return serviceCollection.BuildServiceProvider().
            GetService<ILoggerFactory>()!;
    }

    [TestInitialize]
    public void InitializeDb()
    {
        SqliteConnection = new SqliteConnection("DataSource=:memory:");
        SqliteConnection.Open();

        Options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(SqliteConnection)
            .UseLoggerFactory(GetLoggerFactory())
            .EnableSensitiveDataLogging()
            .Options;

        using var context = new AppDbContext(Options);
        context.Database.EnsureCreated();
    }

    [TestCleanup]
    public void CloseDbConnection()
    {
        SqliteConnection.Close();
    }
}

