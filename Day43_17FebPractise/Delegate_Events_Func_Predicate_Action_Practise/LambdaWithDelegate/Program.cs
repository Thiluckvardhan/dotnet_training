public class Program
{
    public delegate int ExecuteOperation(int a,int b);
    public static void Main()
    {
        ExecuteOperation executeOperation=(a,b)=> a*b;
        System.Console.WriteLine(executeOperation(3,8));
    }
}