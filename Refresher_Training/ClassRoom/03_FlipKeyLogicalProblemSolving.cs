using System.Text;

public class Solution
{
    public static string CleanseAndInvert(string input)
    {
        if(input==null || input.Length < 6)
        {
            return("Invalid Input");
        }
        foreach(char c in input)
        {
            if (!char.IsLetter(c))
            {
                return("Invalid Input");
            }
        }
        List<char> arr=new();
        input=input.ToLower();
        int asci;
        foreach(char c in input)
        {
            asci=(int)c;
            if(asci%2!=0)
            arr.Add(c);
        }
        arr.Reverse();
        for(int i = 0; i < arr.Count; i++)
        {
            if(i%2==0)
            arr[i]=char.ToUpper(arr[i]);
        }
        string cleansedInput=arr.ToArray().ToString();
        return $"The generated key is - {cleansedInput}";
    }
    public static void Main()
    {
        string? i=Console.ReadLine();
        Console.WriteLine($"{CleanseAndInvert(i)}");
    }
}