namespace FindLongestWord
{
    public class Program
    {
        public static void Main()
        {
            System.Console.Write("Give Input: ");
            string input = Console.ReadLine();
            var splitedInput = input.Split(" ");
            int longestWordLength = 0;
            string longestWord = "";
            foreach (string item in splitedInput)
            {
                if (item.Length > longestWordLength)
                {
                    longestWordLength = item.Length;
                    longestWord = item;
                }
            }
            if (longestWordLength == 0)
            {
                System.Console.WriteLine("No Longest Word Possible");
            }
            else
            {
                System.Console.WriteLine($"Longest Word among the given words is: {longestWord}");
            }
        }
    }
}