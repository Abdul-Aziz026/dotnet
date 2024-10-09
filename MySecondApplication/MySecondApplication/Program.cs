var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    string path = context.Request.Path;
    Console.WriteLine(path);

    context.Response.Headers["MyKey"] = "my value";
    context.Response.Headers["Server"] = "Personal Server";
    context.Response.Headers["Content-Type"] = "text/html";
    context.Response.StatusCode = 200;
    await context.Response.WriteAsync("<h2>This</h2> is <b>coding</b> World");
    await context.Response.WriteAsync(path);
});

app.MapGet("/hello", () => "Hello World!");

app.Run();

