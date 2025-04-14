namespace surrender.tracker.Domain;

public class Summoner(string name, string tag, string puuid)
{
    
    public string Name { get; set; } = name;
    public string Tag { get; set; } = tag;
    public string Puuid { get; set; } = puuid;
    public List<string> Matches { get; set; }
}