using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infra.Databases.SqlServers.UCondo;

public class UCondoDesignContext : IDesignTimeDbContextFactory<UCondoContext>
{
    public UCondoContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<UCondoContext>();

        optionsBuilder.UseSqlServer(
            "Data Source=(localdb)\\MsSqlLocalDb;initial catalog=ProductsDbDev;Integrated Security=True; MultipleActiveResultSets=True");

        return new UCondoContext(optionsBuilder.Options);
    }
}