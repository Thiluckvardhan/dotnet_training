using System.Diagnostics;
using System.Text;
namespace LogFormatter
{
    public class Program
    {
        public static void Main()
        {
            int lines = 10000;

            Stopwatch sw = new Stopwatch();

            sw.Start();
            string concatResult = "";
            for (int i = 0; i < lines; i++)
            {
                concatResult += $"Log line {i}\n";
            }
            sw.Stop();
            Console.WriteLine($"+ Concatenation Time: {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < lines; i++)
            {
                sb.Append($"Log line {i}\n");
            }
            string builderResult = sb.ToString();
            sw.Stop();
            Console.WriteLine($"StringBuilder Time: {sw.ElapsedMilliseconds} ms");
        }
    }
}