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
        public DbSet<DateWord> DateWords => Set<DateWord>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //new GameConfiguration().Configure(modelBuilder.Entity<Game>());
            //new WordConfiguration().Configure(modelBuilder.Entity<Word>());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }        
}
