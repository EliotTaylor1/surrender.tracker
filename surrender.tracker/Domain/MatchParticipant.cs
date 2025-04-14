namespace surrender.tracker.Domain;

public record MatchParticipant
{
    public string Puuid { get; set; }
    public bool GameEndedInSurrender { get; set; }
    public bool Win { get; set; }
}