using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using System.Diagnostics;

namespace StoreManagement.Application.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // Log the request details
            _logger.LogInformation("Handling request: {Method} {Path}{QueryString}",
                context.Request.Method, context.Request.Path, context.Request.QueryString);

            // Call the next middleware in the pipeline
            await _next(context);

            stopwatch.Stop();

            // Log the response time
            _logger.LogInformation("Finished handling request. Response time: {ElapsedMilliseconds} ms",
                stopwatch.ElapsedMilliseconds);
        }
    }
}
