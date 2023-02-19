using System.Diagnostics.CodeAnalysis;
using Serilog;

namespace WebApi;

[ExcludeFromCodeCoverage]
public class Program
{
    public static async Task Main(string[] args)
    {
        await CreateHostBuilder(args).UseDefaultServiceProvider(options => options.ValidateScopes = false)
            .Build().RunAsync();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
            .UseSerilog((context, configuration) =>
            {
                configuration.Enrich.FromLogContext()
                    .Enrich.WithMachineName()
                    .WriteTo.Debug()
                    .WriteTo.Console()
                    // .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
                    // {
                    //     AutoRegisterTemplate = true,
                    //     AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
                    //     IndexFormat = "baseapi-{0:yyyy.MM}"
                    // })
                    .Enrich.WithProperty("Environment", Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")!)
                    .ReadFrom.Configuration(context.Configuration);
            });
    }
}