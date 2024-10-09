
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async (HttpContext context) =>
{
    string firstNumber = null;
    context.Response.Headers["Content-Type"] = "text/html";
    if (!context.Request.Query.ContainsKey("firstNumber"))
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Invalid input for firstNumber\n");
    } else
    {
        firstNumber = context.Request.Query["firstNumber"];
    }


    string secondNumber = null;
    if (!context.Request.Query.ContainsKey("secondNumber"))
    {
        Console.WriteLine("Second Number..........................");
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Invalid input for secondNumber\n");
    }
    else
    {
        secondNumber = context.Request.Query["secondNumber"];
    }

    string operation = null;
    if (!context.Request.Query.ContainsKey("operation"))
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Invalid input for operation");
    }
    else
    {
        operation = context.Request.Query["operation"];
    }
    

    if (firstNumber == null || secondNumber == null || operation == null)
    {
        Console.WriteLine("hello I am here1...");

    } else
    {
        Console.WriteLine("hello I am here2...");
        context.Response.StatusCode = 200;
        if (operation == "add") 
        {
            int result = int.Parse(firstNumber) + int.Parse(secondNumber);
            await context.Response.WriteAsync(firstNumber.ToString());
            await context.Response.WriteAsync(" ");
            await context.Response.WriteAsync(operation);
            await context.Response.WriteAsync(" ");
            await context.Response.WriteAsync(secondNumber.ToString());
            await context.Response.WriteAsync(" = ");
            await context.Response.WriteAsync(result.ToString());
        }
        else if (operation == "multiplication")
        {
            int result = int.Parse(firstNumber) * int.Parse(secondNumber);
            await context.Response.WriteAsync(firstNumber.ToString());
            await context.Response.WriteAsync(" ");
            await context.Response.WriteAsync(operation);
            await context.Response.WriteAsync(" ");
            await context.Response.WriteAsync(secondNumber.ToString());
            await context.Response.WriteAsync(" = ");
            await context.Response.WriteAsync(result.ToString());
        }
        else
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Invalid input for operation");
            await context.Response.WriteAsync(" ");
            await context.Response.WriteAsync(firstNumber.ToString());
            await context.Response.WriteAsync(secondNumber.ToString());
        }
    }
});

app.MapGet("/hello", () => "Hello World!");

app.Run();