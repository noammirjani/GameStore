
using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

// DbContext is a object that represents a session with the database and can be used to query and save instances of your entities. Combination of the Unit of Work and Repository patterns.

public class GameStoreContext : DbContext
{
    public GameStoreContext(DbContextOptions<GameStoreContext> options) 
        : base(options)
    {}

    //DbSet - objects that represent tables in the database
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Genre> Genres => Set<Genre>();

    //when we execute the migration command, this method will be called
    // opportunity to configure the model that will be used to create the database
    // dotnet ef migrations add SeedGenres --output-dir Data/Migrations -> create a migration
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new { Id = 1, Name = "Action" },
            new { Id = 2, Name = "Adventure" },
            new { Id = 3, Name = "Racing" },
            new { Id = 4, Name = "Simulation" },
            new { Id = 5, Name = "Strategy" }
        );
    }

}


// public class GameStoreContext(DbContextOptions<GameStoreContext> options) 
// : DbContext(options)
// {}