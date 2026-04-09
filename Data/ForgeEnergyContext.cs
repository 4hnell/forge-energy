using forge_energy.Entities;
using Microsoft.EntityFrameworkCore;

namespace forge_energy.Data;


public class ForgeEnergyContext(DbContextOptions<ForgeEnergyContext> options) : IdentityDbContext<Employee>(options)
{
    public DbSet<FieldOperator> FieldOperators { get; set; }
    public DbSet<Thing> Things { get; set; }
    public DbSet<DistributionSite> DistributionSites { get; set; }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<SomeItem>().HasKey(c => new { c.SomeId, c.OtherId });
    //     base.OnModelCreating(modelBuilder);
    // }
}
