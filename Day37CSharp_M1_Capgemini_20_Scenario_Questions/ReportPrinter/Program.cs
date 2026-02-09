namespace ReportPrinter
{
    public class Program
    {
        public static void PrintReport(string title, int copies = 1, bool showHeader = true)
        {
            for (int i = 1; i <= copies; i++)
            {
                if (showHeader)
                    Console.WriteLine("=== Report Header ===");

                Console.WriteLine($"Printing Report: {title} | Copy {i}");
                Console.WriteLine();
            }
        }

        public static void Main()
        {
            // 1. Default parameters
            PrintReport("Sales Report");

            // 2. Named parameters
            PrintReport(title: "Inventory Report", showHeader: false);

            // 3. Custom copies
            PrintReport("Finance Report", copies: 3);
        }
    }
}
