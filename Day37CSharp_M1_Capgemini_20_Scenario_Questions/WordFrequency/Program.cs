namespace WordFrequency
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string,int> frequency=new();
            System.Console.Write("Enter Input: ");
            string input=Console.ReadLine();
            var splitedInput=input.ToLower().Split(" ");
            string cleanedInput="";
            foreach(var item in splitedInput)
            {
                cleanedInput= new string(item.Where(c=>!char.IsPunctuation(c)).ToArray());
                frequency.TryAdd(cleanedInput,0);
                frequency[cleanedInput]++;
            }
            foreach(var item in frequency)
            {
                System.Console.WriteLine($"{item.Key}  --  {item.Value}");
            }
        }
    }
}