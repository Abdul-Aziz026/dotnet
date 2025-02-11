var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// enable routing...
app.UseRouting();


// creating endpoints...
app.UseEndpoints(endpoints =>
{
    // add your endPoints...
    endpoints.Map("/files/{filename}.{extension}", async (HttpContext context) =>
    {
        string? fileName = context.Request.RouteValues["filename"].ToString();
        string? extension = context.Request.RouteValues["extension"].ToString();
        await context.Response.WriteAsync($"Hello! File request sent...{fileName}.{extension}");
    });

    endpoints.MapGet("/map2", (HttpContext context) =>
    {
        context.Response.WriteAsync("Hello! This is Map2 Get Request...");
    });

    endpoints.MapPost("/map2", (HttpContext context) =>
    {
        context.Response.WriteAsync("Hello! This is Map2 Post Request...");
    });
});

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Common Route...");
});

app.Run();
