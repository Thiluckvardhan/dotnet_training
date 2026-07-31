namespace WareHouse
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Enter Length: ");
            if (!double.TryParse(Console.ReadLine(), out double length) || length<0)
            {
                Console.WriteLine("Invalid Length or Length is Negative");
                return;
            }
            Console.Write("Enter Width: ");
            if (!double.TryParse(Console.ReadLine(), out double width) || width < 0)
            {
                Console.WriteLine("Invalid Width or Width is Negative");
                return;
            }
            Console.Write("Enter Height: ");
            if (!double.TryParse(Console.ReadLine(), out double height) || height < 0)
            {
                Console.WriteLine("Invalid Height or Height is Negative");
                return;
            }

            double volume = length * width * height;
            Console.WriteLine($"Volume : {volume}");
        }
    }
}