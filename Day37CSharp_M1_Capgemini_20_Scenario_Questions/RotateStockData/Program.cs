using System;

namespace RotateStockData
{
    public class Program
    {
        static void Reverse(int[] arr, int start, int end)
        {
            while (start < end)
            {
                int temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                start++;
                end--;
            }
        }

        public static void Main()
        {
            Console.Write("Enter numbers separated by space: ");
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int[] arr = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
                arr[i] = int.Parse(input[i]);

            Console.Write("Enter k (rotation steps): ");
            int k = int.Parse(Console.ReadLine());

            k = k % arr.Length;

            Reverse(arr, 0, arr.Length - 1);
            Reverse(arr, 0, k - 1);
            Reverse(arr, k, arr.Length - 1);

            Console.WriteLine("Rotated Array:");
            foreach (int num in arr)
                Console.Write(num + " ");
        }
    }
}
