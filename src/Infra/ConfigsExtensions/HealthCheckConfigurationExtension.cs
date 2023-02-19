using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Infra.ConfigsExtensions;

public static class HealthCheckConfigurationExtension
{
    public static IApplicationBuilder HealthCheckConfiguration(this IApplicationBuilder app)
    {
        return app
            .UseHealthChecks(new PathString("/liveness"), new HealthCheckOptions
            {
                Predicate = r => r.Name.Contains("self"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            })
            .UseHealthChecks(new PathString("/readiness"), new HealthCheckOptions
            {
                Predicate = r => r.Tags.Contains("readiness"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
    }

    public static IServiceCollection HealthChecksConfiguration(this IServiceCollection services,
        IConfiguration configuration)
    {
        var health = services.AddHealthChecks();
        health
            .AddCheck(
                "self",
                () => HealthCheckResult.Healthy(),
                new[] { "self", "readiness" })
            .AddCheck(
                "readiness",
                () => HealthCheckResult.Healthy())
            .AddSqlServer(
                configuration.GetConnectionString("SqlServer")!,
                tags: new[] { "Sql Server", "readiness" });


        return services;
    }
}