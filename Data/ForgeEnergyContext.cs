using forge_energy.Entities;
using Microsoft.EntityFrameworkCore;

namespace forge_energy.Data;

public class ForgeEnergyContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Thing> Things { get; set; }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<SomeItem>().HasKey(c => new { c.SomeId, c.OtherId });
    //     base.OnModelCreating(modelBuilder);
    // }
}
