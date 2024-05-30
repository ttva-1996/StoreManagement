using Microsoft.AspNetCore.Http;

namespace StoreManagement.Application.Middlewares
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Do something before the request reaches the next middleware
            Console.WriteLine("Custom Middleware executing before handling the request.");

            // Call the next middleware in the pipeline
            await _next(context);

            // Do something after the response has been generated
            Console.WriteLine("Custom Middleware executing after handling the request.");
        }
    }
}
