using Domain.AccountPlan;
using Infra.Databases.SqlServers.UCondo.Configurations;
using Microsoft.EntityFrameworkCore;
#pragma warning disable CS8618

namespace Infra.Databases.SqlServers.UCondo;

public class UCondoContext : DbContext
{
    public UCondoContext(DbContextOptions<UCondoContext> options) : base(options)
    {
    }

    public DbSet<AccountPlanEntity> AccountPlanEntities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountPlanEntityConfiguration());
    }
}