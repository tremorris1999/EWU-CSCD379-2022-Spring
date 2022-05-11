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
        }
    }
}
