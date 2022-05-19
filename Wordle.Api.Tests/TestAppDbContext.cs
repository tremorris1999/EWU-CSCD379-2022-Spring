using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordle.Api.Data;

namespace Wordle.Api.Tests;

public class TestAppDbContext : AppDbContext
{
    public TestAppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Player>().HasData(new Player { PlayerId = 1, Name = "Inigo Montoya" });
        modelBuilder.Entity<Player>().HasData(new Player { PlayerId = 2, Name = "Prince Humperdink" });


    }
}
