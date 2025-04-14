namespace surrender.tracker.Domain;

public record Match
{
    public MatchMetadata Metadata { get; set; }
    public MatchInfo Info { get; set; }
}