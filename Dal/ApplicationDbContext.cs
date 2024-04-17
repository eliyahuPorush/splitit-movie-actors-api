using Dal.Schemas;
using Microsoft.EntityFrameworkCore;

namespace Dal;

public class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "ActorsDb");
        optionsBuilder.EnableSensitiveDataLogging();
    }
    public DbSet<Actor> Actors { get; set; }
}