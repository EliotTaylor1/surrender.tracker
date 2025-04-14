namespace surrender.tracker.Domain;

public record MatchInfo
{
    public long GameCreation { get; set; }
    public long GameId { get; set; }
    public string GameMode { get; set; }
    public string GameName { get; set; }
    public int QueueId { get; set; }
    public List<MatchParticipant> Participants { get; set; }

    public DateTime GetLocalGameTime()
    {
        return DateTimeOffset.FromUnixTimeMilliseconds(GameCreation).LocalDateTime;
    }

}