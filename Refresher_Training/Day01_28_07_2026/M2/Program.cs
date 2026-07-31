using System.Security.Cryptography.X509Certificates;

namespace FitnessProgram
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Enter your Weight in kg: ");
            if(!double.TryParse(Console.ReadLine(),out double Weight))
            {
                Console.WriteLine("Enter only Numbers");
                return;
            }
            if (Weight <= 0)
            {
                Console.WriteLine("Weight Cannot be Negative or Zero");
                return;
            }
            Console.Write("Enter your Height in meters: ");
            if (!double.TryParse(Console.ReadLine(), out double Height))
            {
                Console.WriteLine("Height can only be Numbers");
                return;
            }
            if (Height<= 0)
            {
                Console.WriteLine("Height Cannot be Negative or Zero");
                return;
            }
            double BMI=Math.Round(Weight/(Height*Height),2);
            Console.WriteLine($"Your BMI is: {BMI}");
            if (BMI < 18.5)
                Console.WriteLine("Category: Underweight");
            else if (BMI < 25)
                Console.WriteLine("Category: Normal Weight");
            else if (BMI < 30)
                Console.WriteLine("Category: Overweight");
            else
                Console.WriteLine("Category: Obese");
        }
    }
}