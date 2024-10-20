var builder = WebApplication.CreateBuilder(args);
//var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
//{
//    WebRootPath = "myroot"
//});

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints => {
    endpoints.Map("/", async (context) =>
    {
        await context.Response.WriteAsync("Hello...");
    });


    endpoints.Map("/hello", async (context) =>
    {
        await context.Response.WriteAsync("Ahlan-Sahlan Mahtaram...");
    });
});

app.Run();
