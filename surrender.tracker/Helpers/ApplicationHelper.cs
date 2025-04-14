namespace surrender.tracker.Helpers;

public static class ApplicationHelper
{
    public static string GetSummonerName()
    {
        Console.Write("Summoner ID: ");
        return Console.ReadLine();
    }

    public static string GetSummonerTag()
    {
        Console.Write("Tag: ");
        return Console.ReadLine();
    }

    public static string GetQueueType()
    {
        Console.WriteLine("Select queue type:");
        Console.WriteLine("(1) Solo Queue"); //420
        Console.WriteLine("(2) Flex Queue"); //440
        Console.WriteLine("(3) ARAM");       //450
        Console.Write("Queue: ");
        var choice = Console.ReadLine();
        string queue = null;
        switch (choice)
        {
            case "1": queue = "420"; break;
            case "2": queue = "440"; break;
            case "3": queue = "450"; break;
        }
        return queue;
    }
}