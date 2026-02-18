public class Program
{
    public static void Main()
    {
        Func<int,int,int> result=Maxi(5,6);
        System.Console.WriteLine(result);
    }
    public static int Maxi(int a,int b)
    {
        return Math.Max(a,b);
    }
}