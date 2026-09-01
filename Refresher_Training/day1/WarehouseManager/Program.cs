using System;
class Program
{
    public static void Main(string[] args)
    {
        double length, width, height, volume;

        Console.WriteLine("Enter the length of the box: ");
        while(!double.TryParse(Console.ReadLine(), out length) || length < 0)
        {
            Console.WriteLine("Invalid Input!");
            Console.WriteLine("Enter the length of the box again");
        }

        Console.WriteLine("Enter the width of the box: ");
        while(!double.TryParse(Console.ReadLine(), out width) || width < 0)
        {
            Console.WriteLine("Invalid Input!");
            Console.WriteLine("Enter the width of the box again");
        }

        Console.WriteLine("Enter the height of the box: ");
        while(!double.TryParse(Console.ReadLine(), out height) || height < 0)
        {
            Console.WriteLine("Invalid Input!");
            Console.WriteLine("Enter the length of the box again");
        }
        
        volume = length * width * height;
        volume = Math.Round(volume,2);
        Console.WriteLine($"volume = {volume}");

    }
}