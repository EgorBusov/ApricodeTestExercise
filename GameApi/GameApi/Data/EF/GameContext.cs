using GameApi.Data.EF.EFModels;
using Microsoft.EntityFrameworkCore;

namespace GameApi.Data.EF
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options)
        : base(options)
        {

        }

        public DbSet<GameModel> Games { get; set; }

        public DbSet<GenreModel> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameModel>()
                .HasMany(g => g.Genres)
                .WithMany(g => g.Games)
                .UsingEntity(j => j.ToTable("GameGenres")); 
        }
    }
}
