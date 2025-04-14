using surrender.tracker.Domain;
using surrender.tracker.Helpers;

namespace surrender.tracker.Services;

public class ApplicationService(SummonerService summonerService, MatchesService matchesService)
{
    private readonly SummonerService _summonerService = summonerService;
    private readonly MatchesService _matchesService = matchesService;
    public async Task RunAsync()
    {
        var name = ApplicationHelper.GetSummonerName();
        var tag = ApplicationHelper.GetSummonerTag();
        var queue = ApplicationHelper.GetQueueType();

        var summoner = await _summonerService.CreateSummonerAsync(name, tag);
        summoner.Matches = await _matchesService.GetMatchesAsync(summoner.Puuid, queue);
        var matchDetails = await _matchesService.GetMatchDetailsAsync(summoner.Matches);

        var lostMatches = _matchesService.GetLostSurrenderedMatches(matchDetails, summoner.Puuid);
        var wonMatches = _matchesService.GetWonSurrenderedMatches(matchDetails, summoner.Puuid);

        Console.WriteLine($"\nWon from enemy FF: {wonMatches.Count} / 100");
        foreach (var match in wonMatches)
        {
            PrintMatch(match);
        }

        Console.WriteLine($"\nLost from FF: {lostMatches.Count} / 100");
        foreach (var match in lostMatches)
        {
            PrintMatch(match);
        }
    }

    private void PrintMatch(Match match)
    {
        var trimmedId = match.Metadata.MatchId.Replace("EUW1_", "");
        Console.WriteLine($"{match.Metadata.MatchId} - {match.Info.GetLocalGameTime():dd-MM-yyyy HH:mm:ss} - https://www.leagueofgraphs.com/match/euw/{trimmedId}");
    }
}