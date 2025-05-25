using GameStore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    public DbSet<Game> Games { get; set; } = null!;
    public DbSet<Genre> Genres { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = 1, Name = "Action RPG" },
            new Genre { Id = 2, Name = "Action Adventure" },
            new Genre { Id = 3, Name = "Adventure" },
            new Genre { Id = 4, Name = "First-Person Shooter" },
            new Genre { Id = 5, Name = "Third-Person Shooter" },
            new Genre { Id = 6, Name = "Survival Horror" },
            new Genre { Id = 7, Name = "Metroidvania" },
            new Genre { Id = 8, Name = "Platformer" }
        );
    }
 }
