using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IO;

namespace Infra.Middlewares;

public class LoggingMiddleware
{
    private readonly ILogger<LoggingMiddleware> _logger;
    private readonly RequestDelegate _next;
    private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;

    public LoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
    {
        _next = next;
        _logger = loggerFactory
            .CreateLogger<LoggingMiddleware>();
        _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
    }


    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Path.Value!.Contains("swagger"))
        {
            await _next(context);
        }
        else
        {
            await LogRequest(context);
            await LogResponse(context);
        }
    }

    private async Task LogResponse(HttpContext context)
    {
        var originalBodyStream = context.Response.Body;
        await using var responseBody = _recyclableMemoryStreamManager.GetStream();
        context.Response.Body = responseBody;
        await _next(context);
        context.Response.Body.Seek(0, SeekOrigin.Begin);
        _logger.LogInformation(
            $"Http Response Information: {Environment.NewLine} Schema:{context.Request.Scheme} Host: {context.Request.Host} Path: {context.Request.Path} QueryString: {context.Request.QueryString}");
        await responseBody.CopyToAsync(originalBodyStream);
    }

    private async Task LogRequest(HttpContext context)
    {
        context.Request.EnableBuffering();
        await using var requestStream = _recyclableMemoryStreamManager.GetStream();
        await context.Request.Body.CopyToAsync(requestStream);
        var log =
            $"Http Request Information: {Environment.NewLine} Schema:{context.Request.Scheme} Host: {context.Request.Host} Path: {context.Request.Path} QueryString: {context.Request.QueryString}";
        _logger.LogInformation(log);
        context.Request.Body.Position = 0;
    }
}