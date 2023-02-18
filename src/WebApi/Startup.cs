using System.Text.Json;
using System.Text.Json.Serialization;
using Infra.ConfigsExtensions;
using Infra.Databases.SqlServers.UCondo.Extensions;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.OpenApi.Models;

namespace WebApi;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

                
        services.AddResponseCompression(options =>
        {
            options.Providers.Add<GzipCompressionProvider>();
            options.EnableForHttps = true;
        });

        services.AddEndpointsApiExplorer()
            .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Base API", Version = "v1" });
                    c.UseInlineDefinitionsForEnums();
                }
            );

        services
            .HealthChecksConfiguration(_configuration)
            .AddUCondoContext(_configuration)
            .AddDomainServices();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {

        if (env.IsDevelopment())
        {
            app.ExecuteMigartions();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection().UseRouting()
            .UseResponseCompression()
            .UseEndpoints(builder => { builder.MapControllers(); })
            .UseAuthorization()
            .HealthCheckConfiguration();
    }
}