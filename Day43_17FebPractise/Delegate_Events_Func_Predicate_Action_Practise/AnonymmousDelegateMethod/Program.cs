public class Program
{
    public delegate bool CheckDelegate(int number);
    public static void Main()
    {
        CheckDelegate isPositve=delegate(int number)
        {
            return number>=0;
        };
        System.Console.WriteLine(isPositve(-15));
    }
}