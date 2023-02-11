using Microsoft.EntityFrameworkCore;
using Models;

namespace Data;

public class UnrealContext : DbContext
{
    public UnrealContext(DbContextOptions<UnrealContext> options) : base(options)
    {
    }

    public static async Task InitializeAsync(UnrealContext context)
    {
        await context.Database.MigrateAsync();
    }

    public DbSet<Project> Projects { get; set; }
    public DbSet<PoI> PoIs { get; set; }
    public DbSet<Panorama> Panoramas { get; set; }
    public DbSet<Screenshot> Screenshots { get; set; }
}
