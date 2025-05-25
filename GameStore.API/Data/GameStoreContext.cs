using GameStore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    public DbSet<Game> Games { get; set; } = null!;
    public DbSet<Genre> Genres { get; set; } = null!;
}
