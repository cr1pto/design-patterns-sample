using DesignPatterns.Lib.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddTransient<IPatternFetcher, PatternFetcher>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", () =>
{
    return Results.Ok("it works");
})
.WithName("ItWorks");

app.MapGet("/patterns/{name}", (string name, IPatternFetcher patternFetcher) =>
{
    object response = patternFetcher.FetchPattern(name);
    return Results.Ok("Pattern: " + name + " Response: " + response);
})
.WithName("Patterns");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
