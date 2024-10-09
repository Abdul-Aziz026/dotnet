
namespace MiddleWareLearn.CustomMiddleware
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("This is Middleware 2 starts....\n");
            next(context);
            await context.Response.WriteAsync("This is Middleware 2 ends....\n");
        }
    }

    // custom Extension middleware...
    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyCustomMiddleware>();
        }
    }
}
