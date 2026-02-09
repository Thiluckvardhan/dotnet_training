using System;

namespace SalesAnalysis
{
    public class Program
    {
        public static void Main()
        {
            int[] sales = new int[7];

            Console.WriteLine("Enter sales for 7 days:");

            for (int i = 0; i < 7; i++)
            {
                Console.Write($"Day {i + 1}: ");
                sales[i] = int.Parse(Console.ReadLine());
            }

            int max = sales[0];
            int min = sales[0];
            int maxDay = 0;
            int total = 0;

            for (int i = 0; i < sales.Length; i++)
            {
                if (sales[i] > max)
                {
                    max = sales[i];
                    maxDay = i;
                }

                if (sales[i] < min)
                    min = sales[i];

                total += sales[i];
            }

            double avg = (double)total / sales.Length;

            Console.WriteLine($"Highest Sale: {max}");
            Console.WriteLine($"Lowest Sale: {min}");
            Console.WriteLine($"Average Sale: {avg}");
            Console.WriteLine($"Day with Highest Sale: Day {maxDay + 1}");
        }
    }
}
