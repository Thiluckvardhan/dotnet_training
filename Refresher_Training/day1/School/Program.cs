using System;
class Program
{
    public static void Main(string[] args)
    {
        double m1, m2, m3 , m4 , m5;

        Console.WriteLine("Enter the marks of subject 1");
        while(!double.TryParse(Console.ReadLine(), out m1) || m1 < 0 || m1 > 100)
        {
            Console.WriteLine("Invalid Input!");
            Console.WriteLine("Enter the marks of subject 1 again! ");
        }

        Console.WriteLine("Enter the marks of subject 2");
        while(!double.TryParse(Console.ReadLine(), out m2) || m2 < 0 || m2 > 100)
        {
            Console.WriteLine("Invalid Input!");
            Console.WriteLine("Enter the marks of subject 2 again! ");
        }

        Console.WriteLine("Enter the marks of subject 3");
        while(!double.TryParse(Console.ReadLine(), out m3) || m3 < 0 || m3 > 100)
        {
            Console.WriteLine("Invalid Input!");
            Console.WriteLine("Enter the marks of subject 3 again! ");
        }

        Console.WriteLine("Enter the marks of subject 4");
        while(!double.TryParse(Console.ReadLine(), out m4) || m4 < 0 || m4 > 100)
        {
            Console.WriteLine("Invalid Input!");
            Console.WriteLine("Enter the marks of subject 4 again! ");
        }

        Console.WriteLine("Enter the marks of subject 5");
        while(!double.TryParse(Console.ReadLine(), out m5) || m5 < 0 || m5 > 100)
        {
            Console.WriteLine("Invalid Input!");
            Console.WriteLine("Enter the marks of subject 5 again! ");
        }

        double totalMarks = m1+m2+m3+m4+m5;
        double average = totalMarks/5;
        double percentage = (totalMarks/500) * 100;

        average = Math.Round(average, 2);
        percentage = Math.Round(percentage, 2);

        Console.WriteLine($"Total Marks = {totalMarks}");
        Console.WriteLine($"Average Marks = {average:F2}");
        Console.WriteLine($"Percentage = {percentage:F2}%");

    }
}