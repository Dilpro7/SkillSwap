using System.Diagnostics;

namespace SkillSwap.API.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var method = context.Request.Method;
            var path = context.Request.Path;

            Console.WriteLine($"Request: {method} {path} at {DateTime.Now}");

            await _next(context);
        }
    }
}