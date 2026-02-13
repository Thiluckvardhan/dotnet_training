namespace WebAPIFectch
{

    public class program
    {
        public static async Task Fetcher()
        {
            using HttpClient client=new();
            string result= await client.GetStringAsync("https://jsonplaceholder.typicode.com/todos/");
            System.Console.WriteLine(result);
        }
        public static async Task Main()
        {
            await Fetcher();
        }
    }
}