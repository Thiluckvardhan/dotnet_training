using System;
using System.Text;

namespace computerscienceinstructor
{
    internal class Program
    {
        public static string CleanseAndInvert(string input)
        {
            if (string.IsNullOrWhiteSpace(input) || input.Length < 6)
                return string.Empty;

            foreach (char ch in input)
            {
                if (!char.IsLetter(ch))
                    return string.Empty;
            }

            StringBuilder filtered = new StringBuilder();

            foreach (char ch in input.ToLower())
            {
                if (ch % 2 != 0)
                    filtered.Append(ch);
            }

            char[] result = filtered.ToString().ToCharArray();
            Array.Reverse(result);

            for (int i = 0; i < result.Length; i++)
            {
                if (i % 2 == 0)
                    result[i] = char.ToUpper(result[i]);
            }

            return new string(result);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the word");
            string input = Console.ReadLine();

            string result = CleanseAndInvert(input);

            if (string.IsNullOrEmpty(result))
                Console.WriteLine("Invalid Input");
            else
                Console.WriteLine($"The generated key is - {result}");
        }
    }
}
