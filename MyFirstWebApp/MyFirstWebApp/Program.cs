var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Alhamdulillah! Hey welcome to the web development field...");

app.Run();
