using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GameStore.API.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<GameStoreContext>
{
    public GameStoreContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<GameStoreContext>();
        optionsBuilder.UseSqlite("Data Source=GameStore.db");

        return new GameStoreContext(optionsBuilder.Options);
    }
} 
