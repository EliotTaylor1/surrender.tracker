using System.Text.Json;
using surrender.tracker.Domain;

namespace surrender.tracker.Services;

public class MatchesService(IHttpClientFactory httpClientFactory)
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

    public async Task<List<string>> GetMatchesAsync(string puuid, string queue)
    {
        var client = _httpClientFactory.CreateClient("MatchesHttpClient");

        var response = await client.GetAsync($"by-puuid/{puuid}/ids?queue={queue}&start=0&count=100");
        response.EnsureSuccessStatusCode();
        var jsonResponse = await response.Content.ReadAsStringAsync();

        var matchIds = JsonSerializer.Deserialize<List<string>>(jsonResponse);

        if (matchIds == null)
        {
            throw new Exception("No Match IDs");
        }
        return matchIds;
    }

    public async Task<List<Match>> GetMatchDetailsAsync(List<string> matchIds)
    {
        var client = _httpClientFactory.CreateClient("MatchesHttpClient");
        
        var matches = new List<Match>();
        for (var i = 0; i < matchIds.Count; i++)
        {
            Console.WriteLine($"#{i} - Starting: {matchIds[i]}");
            await Task.Delay(200);
            var matchResponse = await client.GetAsync($"{matchIds[i]}");
            matchResponse.EnsureSuccessStatusCode();
            var json = await matchResponse.Content.ReadAsStringAsync();
            var match = JsonSerializer.Deserialize<Match>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            matches.Add(match);
            Console.WriteLine($"#{i} - Done: {matchIds[i]}");
        }
        return matches;
    }

    public List<Match> GetWonSurrenderedMatches(List<Match> matches, string puuid)
    {
        var wonSurrendered = (
            from match in matches
            from participant in match.Info.Participants
            where participant.Puuid == puuid 
                  && participant.Win 
                  && participant.GameEndedInSurrender
            select match
            ).ToList();
        return wonSurrendered;
    }
    
    public List<Match> GetLostSurrenderedMatches(List<Match> matches, string puuid)
    {
        var lostSurrendered = (
            from match in matches
            from participant in match.Info.Participants
            where participant.Puuid == puuid 
                  && !participant.Win 
                  && participant.GameEndedInSurrender
            select match
        ).ToList();
        return lostSurrendered;
    }
}