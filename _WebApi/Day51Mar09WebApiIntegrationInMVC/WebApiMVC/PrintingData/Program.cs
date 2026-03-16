using System.Net.Http.Json;



// Fake API call from Program.cs
using (var client = new HttpClient())
{
    client.BaseAddress = new Uri("https://localhost:7111/api/Food");

    var users = await client.GetFromJsonAsync<List<Food>>("");

    if (users != null)
    {
        foreach (var user in users)
        {
            Console.WriteLine($"{user.Id} - {user.Name} - {user.Price } - {user.Quantity}");
        }
    }
}

public class Food
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int Quantity { get; set; }
}