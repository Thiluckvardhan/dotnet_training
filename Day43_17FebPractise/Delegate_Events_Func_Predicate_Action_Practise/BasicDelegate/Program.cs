namespace BasicDelegate
{
    public delegate int Adddelegate(int a, int b);
    public class Program
    {
        public static void Main()
        {
            Adddelegate adddelegate = Add;
            int result = adddelegate(5, 6);
            System.Console.WriteLine(result);
        }
        public static int Add(int a, int b)
        {
            return a + b;
        }
    }
}