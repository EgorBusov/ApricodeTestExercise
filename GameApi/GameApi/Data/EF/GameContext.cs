using GameApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GameApi.Data.EF
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options)
        : base(options)
        {

        }

        DbSet<Game> Games { get; set; }
    }
}
