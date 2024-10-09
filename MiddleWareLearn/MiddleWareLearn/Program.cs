using MiddleWareLearn.CustomMiddleware;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();


var app = builder.Build();

// Middleware that runs only for paths that start with /admin
app.UseWhen(context => context.Request.Path.StartsWithSegments("/admin"), appBuilder =>
{
    appBuilder.Use(async (context, next) =>
    {
        // Custom logic for /admin paths
        Console.WriteLine("Admin area accessed.");
        await context.Response.WriteAsync("Admin Middleware\n");
        await next();
    });
});

// middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    Console.WriteLine("Middleware 1 starts");
    await context.Response.WriteAsync("Alhamdulillah.! 1st Middleware...\n");
    await next(context);
    Console.WriteLine("Middleware 1 ends");
});


// app.UseMiddleware<HelloCustomMiddleware>();
// middleware 2 
// app.UseMiddleware<MyCustomMiddleware>();
// app.UseMyCustomMiddleware();
app.UseHelloCustomMiddleware();

// middleware 3
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("3rd MiddleWare calls beautifully...\n");
});

app.MapGet("/", (HttpContext context) => "Hello World!");

app.Run();
