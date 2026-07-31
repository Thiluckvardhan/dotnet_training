using System.Security.Cryptography.X509Certificates;

namespace SchoolPerformance;

public class Program
{
    public static void Main()
    {
        Console.Write("Enter marks in 1st subject:  ");
        if (!double.TryParse(Console.ReadLine(), out double marks1) || marks1 < 0 || marks1>100)
        {
            Console.WriteLine("Enter marks in Numbers only and betweeen 0 and 100");
            return;
        }
        Console.Write("Enter marks in 2nd subject:  ");
        if (!double.TryParse(Console.ReadLine(), out double marks2) || marks2 < 0 || marks2 > 100)
        {
            Console.WriteLine("Enter marks in Numbers only and betweeen 0 and 100");
            return;
        }
        Console.Write("Enter marks in 3rd subject:  ");
        if (!double.TryParse(Console.ReadLine(), out double marks3) || marks3 < 0 || marks3 > 100)
        {
            Console.WriteLine("Enter marks in Numbers only and betweeen 0 and 100");
            return;
        }
        Console.Write("Enter marks in 4th subject:  ");
        if (!double.TryParse(Console.ReadLine(), out double marks4) || marks4 < 0 || marks4 > 100)
        {
            Console.WriteLine("Enter marks in Numbers only and betweeen 0 and 100");
            return;
        }
        Console.Write("Enter marks in 5th subject:  ");
        if (!double.TryParse(Console.ReadLine(), out double marks5) || marks5 < 0 || marks5 > 100)
        {
            Console.WriteLine("Enter marks in Numbers only and betweeen 0 and 100");
            return;
        }

        double total = marks1 + marks2 + marks3 + marks4 + marks5;
        double average = total / 5;
        double percentage = (total / 500) * 100;

        Console.WriteLine($"Total Marks obtained: {total:F2}");
        Console.WriteLine($"Average Marks obtained: {average:F2}");
        Console.WriteLine($"Percentage obtained: {percentage:F2}");
    }
}