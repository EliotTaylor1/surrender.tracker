namespace surrender.tracker.Domain;

public record MatchMetadata
{
    public string MatchId { get; set; }
    public List<string> Participants { get; set; }
}