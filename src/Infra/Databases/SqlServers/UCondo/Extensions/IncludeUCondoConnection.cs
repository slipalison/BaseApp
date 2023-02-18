using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Databases.SqlServers.UCondo.Extensions;

public static class IncludeUCondoConnection
{
    public static void AddUCondoContext(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContextPool<UCondoContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServer")));
    }
    
    public static void ExecuteMigartions(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var dbContext = serviceScope.ServiceProvider.GetRequiredService<UCondoContext>();
        dbContext.Database.EnsureCreated();
    }
}