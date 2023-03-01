using Microsoft.EntityFrameworkCore;
using Coolicky.ConstructionLogistics.Models;

namespace Coolicky.ConstructionLogistics.Data;

public class UnrealContext : DbContext
{
    public UnrealContext(DbContextOptions<UnrealContext> options) : base(options)
    {
    }

    public static async Task InitializeAsync(UnrealContext context)
    {
        var isMigrationNeeded = (await context.Database.GetPendingMigrationsAsync()).Any();
        if (isMigrationNeeded) await context.Database.MigrateAsync();
    }

    public DbSet<Project> Projects { get; set; }
    public DbSet<PoI> PoIs { get; set; }
    public DbSet<Panorama> Panoramas { get; set; }
    public DbSet<Screenshot> Screenshots { get; set; }
}