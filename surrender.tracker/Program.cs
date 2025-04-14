using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using surrender.tracker.Services;

Console.Write("Enter API Key: ");
var key = Console.ReadLine();

var builder = Host.CreateApplicationBuilder(args);

// Register services
builder.Services.AddSingleton<SummonerService>();
builder.Services.AddSingleton<MatchesService>();
builder.Services.AddSingleton<ApplicationService>();

// Register HTTP clients
builder.Services.AddHttpClient("MatchesHttpClient", client =>
{
    client.BaseAddress = new Uri("https://europe.api.riotgames.com/lol/match/v5/matches/");
    client.DefaultRequestHeaders.Add("X-Riot-Token", key);
    client.Timeout = TimeSpan.FromSeconds(30);
});

builder.Services.AddHttpClient("SummonerHttpClient", client =>
{
    client.BaseAddress = new Uri("https://europe.api.riotgames.com/riot/account/v1/accounts/by-riot-id/");
    client.DefaultRequestHeaders.Add("X-Riot-Token", key);
    client.Timeout = TimeSpan.FromSeconds(30);
});

var host = builder.Build();

var app = host.Services.GetRequiredService<ApplicationService>();
await app.RunAsync();