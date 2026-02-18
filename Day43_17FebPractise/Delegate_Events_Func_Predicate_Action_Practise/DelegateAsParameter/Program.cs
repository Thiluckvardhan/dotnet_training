public class Program
{
    public delegate int Operation(int a,int b);
    public static void Main()
    {
        Operation result=Add;
        System.Console.WriteLine(Execute(result,5,6));
    }
    public static int Execute(Operation op,int a,int b)
    {
        return op(a,b);
    }

    public static int Add(int a,int b)
    {
        return a+b;
    }
}