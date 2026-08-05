using System;
namespace Swaping
{
    public class Program
    {
        public void SwapRef(ref int a, ref int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;
        }
        public void SwapOut(int a, int b, out int x, out int y)
        {
            x = b;
            y = a;
        }
        public static void Main()
        {
            Program program = new Program();
            Console.WriteLine("Swapping Numbers:");
            Console.Write("Enter Number 1: ");
            if (!int.TryParse(Console.ReadLine(), out int num1)){
                Console.WriteLine("Enter only Integers");
                return;
            }
            Console.Write("Enter Number 2: ");
            if (!int.TryParse(Console.ReadLine(), out int num2)){
                Console.WriteLine("Enter only Integers");
                return;
            }

            program.SwapRef(ref num1, ref num2);
            Console.WriteLine($"Swap after Ref {num1}, {num2}");
            program.SwapOut(num1, num2, out int x, out int y);
            Console.WriteLine($"Swap after Out {x}, {y}");
            return;
        }
    }
}
