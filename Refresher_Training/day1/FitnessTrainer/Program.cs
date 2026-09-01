using System;
class Program
{
    public static void Main(string[] args)
    {
        double weight, height, bmi;
        
        Console.WriteLine("Enter your weight in KGs");
        while(!double.TryParse(Console.ReadLine(),out weight)|| weight<=0)
        {
            Console.WriteLine("Invalid Input");
            Console.WriteLine("Enter your weight in KGs again! : ");
        }

        Console.WriteLine("Enter your height in meters");
        while(!double.TryParse(Console.ReadLine(),out height)|| height<=0)
        {
            Console.WriteLine("Invalid Input");
            Console.WriteLine("Enter your height in meters again! : ");
        }

        bmi = weight /(height * height);
        bmi = Math.Round(bmi,2);

        Console.WriteLine($"Your BMI is: {bmi}");

    }
}