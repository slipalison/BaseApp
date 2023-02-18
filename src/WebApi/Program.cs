using System.Text.Json;
using System.Text.Json.Serialization;
using Infra.ConfigsExtensions;
using Infra.Databases.SqlServers.UCondo.Extensions;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Sinks.Elasticsearch;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(new LoggerConfiguration()
    .Enrich.FromLogContext()
    .Enrich.WithMachineName()
    .WriteTo.Debug()
    .WriteTo.Console()
    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
    {
        AutoRegisterTemplate = true,
        AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
        IndexFormat = "baseapi-{0:yyyy.MM}"
    })
    .Enrich.WithProperty("Environment", Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")!)
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger());

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer()
    .AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Base API", Version = "v1" });

            c.UseInlineDefinitionsForEnums();
        }
    );

builder.Services.HealthChecksConfiguration(builder.Configuration).AddUCondoContext(builder.Configuration);


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.ExecuteMigartions();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.HealthCheckConfiguration();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();