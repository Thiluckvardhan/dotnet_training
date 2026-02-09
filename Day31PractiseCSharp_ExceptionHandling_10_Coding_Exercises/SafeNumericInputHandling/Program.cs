using System;

class InputHandler
{
    static void Main()
    {
        // TODO:
        // 1. Read input from user
        // 2. Handle invalid numeric input
        // 3. Keep asking until valid number is entered
        while (true)
        {
            System.Console.Write("Enter only Numeric Input: ");
            if(int.TryParse(Console.ReadLine(),out int input))
            {
                System.Console.WriteLine("Input taken Sucessfully");
                break;
            }
        }
    }
}