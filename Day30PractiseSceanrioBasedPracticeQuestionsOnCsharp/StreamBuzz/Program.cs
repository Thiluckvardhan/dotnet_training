using System;
using System.Collections.Generic;

#region Models

public class CreatorStats
{
    public string CreatorName { get; set; }
    public double[] WeeklyLikes { get; set; }

    public static List<CreatorStats> EngagementBoard { get; } = new List<CreatorStats>();

    public static void RegisterCreator(CreatorStats record)
    {
        EngagementBoard.Add(record);
    }

    public static Dictionary<string, int> GetTopPostCounts(double likeThreshold)
    {
        Dictionary<string, int> result = new Dictionary<string, int>();

        foreach (var creator in EngagementBoard)
        {
            int count = 0;

            foreach (var likes in creator.WeeklyLikes)
            {
                if (likes >= likeThreshold)
                    count++;
            }

            if (count > 0)
                result.Add(creator.CreatorName, count);
        }

        return result;
    }

    public static double CalculateAverageLikes()
    {
        double totalLikes = 0;
        int totalWeeks = 0;

        foreach (var creator in EngagementBoard)
        {
            foreach (var likes in creator.WeeklyLikes)
                totalLikes += likes;

            totalWeeks += creator.WeeklyLikes.Length;
        }

        return totalWeeks == 0 ? 0 : totalLikes / totalWeeks;
    }
}

#endregion

public class Program
{
    private const int Weeks = 4;

    public static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("1. Register Creator");
            Console.WriteLine("2. Show Top Posts");
            Console.WriteLine("3. Calculate Average Likes");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter your choice:");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter Creator Name:");
                    string name = Console.ReadLine();

                    double[] likes = new double[Weeks];
                    Console.WriteLine("Enter weekly likes:");

                    for (int i = 0; i < Weeks; i++)
                    {
                        while (!double.TryParse(Console.ReadLine(), out likes[i]))
                        {
                            Console.WriteLine("Invalid input. Enter a number:");
                        }
                    }

                    CreatorStats.RegisterCreator(new CreatorStats
                    {
                        CreatorName = name,
                        WeeklyLikes = likes
                    });

                    Console.WriteLine("Creator registered successfully\n");
                    break;

                case "2":
                    Console.WriteLine("Enter like threshold:");
                    if (double.TryParse(Console.ReadLine(), out double threshold))
                    {
                        var results = CreatorStats.GetTopPostCounts(threshold);

                        if (results.Count == 0)
                            Console.WriteLine("No top-performing posts");
                        else
                            foreach (var item in results)
                                Console.WriteLine($"{item.Key} - {item.Value}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid threshold");
                    }
                    Console.WriteLine();
                    break;

                case "3":
                    Console.WriteLine($"Overall average weekly likes: {CreatorStats.CalculateAverageLikes()}\n");
                    break;

                case "4":
                    Console.WriteLine("Logging off - Keep Creating with StreamBuzz!");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice\n");
                    break;
            }
        }
    }
}
