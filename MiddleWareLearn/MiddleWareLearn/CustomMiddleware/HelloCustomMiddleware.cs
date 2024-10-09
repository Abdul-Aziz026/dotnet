using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddleWareLearn.CustomMiddleware
{
    public class HelloCustomMiddleware
    {
        private readonly RequestDelegate _next;

        public HelloCustomMiddleware(RequestDelegate next)
        {
            Console.WriteLine("Next initialize...");
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            Console.WriteLine("Invoke fun calls...");
            // before code
            await httpContext.Response.WriteAsync("Middleware Starts...\n");
            await _next(httpContext);
            // after code
            httpContext.Response.WriteAsync("Middleware Ends...\n");

            Console.WriteLine("Invoke fun calls ends...");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseHelloCustomMiddleware(this IApplicationBuilder builder)
        {
            Console.WriteLine("Hello Middle start");
            return builder.UseMiddleware<HelloCustomMiddleware>();
            Console.WriteLine("Hello Middle end");
        }
    }
}
