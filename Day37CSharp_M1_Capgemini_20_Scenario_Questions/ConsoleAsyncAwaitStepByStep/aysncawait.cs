using System.Net.Http;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
await FetchJsonAsync();

     async Task FetchJsonAsync()
    {
         

HttpClient _http=new HttpClient();
        try
        {
            string url = "https://jsonplaceholder.typicode.com/todos";
            string json = await _http.GetStringAsync(url);

            if (string.IsNullOrEmpty(json))
            {
                 Console.WriteLine("No Resu;t") ;   
            }

             Console.WriteLine (json + Environment.NewLine);
              Console.WriteLine ("Status: Success");
        }
        catch (Exception ex)
        {
            Console.WriteLine ("Error: " + ex.Message + Environment.NewLine);
             Console.WriteLine ( "Status: Failed");
        }
        finally
        {
            Console.WriteLine("Done");
        }
    };