using forge_energy.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace forge_energy.Data;

public class ForgeEnergyContext(DbContextOptions options) : IdentityDbContext<User>(options)
{
    public DbSet<FieldOperator> FieldOperators { get; set; }
    public DbSet<IssueReport> IssueReports { get; set; }
    public DbSet<Substation> Substations { get; set; }
    public DbSet<DistributionSite> DistributionSites { get; set; }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<SomeItem>().HasKey(c => new { c.SomeId, c.OtherId });
    //     base.OnModelCreating(modelBuilder);
    // }
}
