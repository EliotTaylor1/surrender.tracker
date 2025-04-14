using System.Text.Json;
using surrender.tracker.Domain;

namespace surrender.tracker.Services;

public class SummonerService(IHttpClientFactory httpClientFactory)
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

    public async Task<Summoner> CreateSummonerAsync(string name, string tag)
    {
        HttpClient client = _httpClientFactory.CreateClient("SummonerHttpClient");
        
        var response = await client.GetAsync($"{name}/{tag}");
        response.EnsureSuccessStatusCode();
        var jsonResponse = await response.Content.ReadAsStringAsync();

        using var jsonDoc = JsonDocument.Parse(jsonResponse);
        var puuid = jsonDoc.RootElement.GetProperty("puuid").GetString();

        return new Summoner(name, tag, puuid!);
    }
}