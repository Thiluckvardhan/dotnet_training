using System;
using System.Collections.Generic;

namespace RemoveDuplicates
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Enter numbers separated by space: ");
            string[] input = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int[] numbers = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
                numbers[i] = int.Parse(input[i]);

            List<int> uniqueList = new List<int>();

            foreach (int num in numbers)
            {
                if (!uniqueList.Contains(num))
                    uniqueList.Add(num);
            }

            Console.WriteLine("Unique values:");
            foreach (int num in uniqueList)
                Console.Write(num + " ");
        }
    }
}
