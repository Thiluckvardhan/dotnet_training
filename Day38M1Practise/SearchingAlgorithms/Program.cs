namespace SearchingAlgorithms
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            int rightSum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                rightSum += (int)input[i] - (int)'a' + 1;
            }
            int leftSum = 0;
            char result = '-';
            int currVal = 0;
            for (int i = 0; i < input.Length; i++)
            {
                currVal = (int)input[i] - (int)'a' + 1;
                rightSum -= currVal;
                if (leftSum == rightSum)
                {
                    result = input[i];
                    break;
                }
                leftSum += currVal;
            }
            if (result == '-')
            {
                System.Console.WriteLine("404");
            }
            else
            {
                System.Console.WriteLine(result);
            }
        }
    }
}