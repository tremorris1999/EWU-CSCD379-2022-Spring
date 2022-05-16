using Microsoft.EntityFrameworkCore;

namespace Wordle.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ScoreStat> ScoreStats => Set<ScoreStat>();
        public DbSet<Player> Players => Set<Player>();
        public DbSet<Word> Words => Set<Word>();
        public DbSet<Game> Games => Set<Game>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Player>().HasData(new Player { PlayerId = 1, Name = "Inigo Montoya" });
            modelBuilder.Entity<Player>().HasData(new Player { PlayerId = 2, Name = "Prince Humperdink" });

            modelBuilder.Entity<ScoreStat>().HasData(new ScoreStat { ScoreStatId = 1, Score = 1 });
            modelBuilder.Entity<ScoreStat>().HasData(new ScoreStat { ScoreStatId = 2, Score = 2 });
            modelBuilder.Entity<ScoreStat>().HasData(new ScoreStat { ScoreStatId = 3, Score = 3 });
            modelBuilder.Entity<ScoreStat>().HasData(new ScoreStat { ScoreStatId = 4, Score = 4 });
            modelBuilder.Entity<ScoreStat>().HasData(new ScoreStat { ScoreStatId = 5, Score = 5 });
            modelBuilder.Entity<ScoreStat>().HasData(new ScoreStat { ScoreStatId = 6, Score = 6 });
        }
    }
}
