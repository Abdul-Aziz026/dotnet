using Route.CustomConstraints;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("months", typeof(MonthsCustomConstraint));
});
var app = builder.Build();

// enable routing...
app.UseRouting();

// creating endpoints...
app.UseEndpoints(endpoints =>
{
    // add your endPoints...
    endpoints.Map("/files/{filename=pdf}", async (HttpContext context) =>
    {
        string? fileName = context.Request.RouteValues["filename"].ToString();
        // string? extension = context.Request.RouteValues["extension"]?.ToString() ?? "pdf";
        await context.Response.WriteAsync($"Hello! File request sent...{fileName}");
    });

    endpoints.MapGet("/map2", (HttpContext context) =>
    {
        context.Response.WriteAsync("Hello! This is Map2 Get Request...");
    });

    endpoints.MapPost("/map2", (HttpContext context) => 
    {
        context.Response.WriteAsync("Hello! This is Map2 Post Request...");
    });


    endpoints.Map("/employee/profile/{employeename:length(3, 10)=Abdullah}", async (HttpContext context) =>
    {
        string employeeName = context.Request.RouteValues["employeename"]?.ToString();  // Provide default value "Abdullah"
        await context.Response.WriteAsync($"Employee profile: {employeeName}");
    });

    endpoints.Map("/products/details/{id:int?}", async (HttpContext context) =>
    {
        await context.Response.WriteAsync($"Products Route...{context.Request.Path}");
    });


    // daily digest-report.../{reportdate}
    endpoints.Map("/daily-digest-report/{reportdate:datetime?}", async (context) =>
    {
        DateTime reportDate = Convert.ToDateTime(context.Request.RouteValues["reportdate"]);
        await context.Response.WriteAsync($"Report-date is : {reportDate.ToShortDateString()}");
    });

    endpoints.Map("sales-report/{year:int:min(1900)}/{month:months}", async (context) =>
    {
        int year = Convert.ToInt32(context.Request.RouteValues["year"]);
        string month = Convert.ToString(context.Request.RouteValues["month"]);
        if (month=="apr" || month=="jul" || month=="oct" || month=="jan")
        {
            await context.Response.WriteAsync($"Sales Report - {year} - {month}.");
        }
        else
        {
            await context.Response.WriteAsync("Wrong Url");
        }
    });
});

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync($"Common Route...{context.Request.Path}");
});

app.Run();
