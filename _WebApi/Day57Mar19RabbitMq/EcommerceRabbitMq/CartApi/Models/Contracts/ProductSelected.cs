namespace CartApi.Models.Contracts;

public class ProductSelected
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public DateTime SelectedAtUtc { get; set; }
    public Dictionary<string, string>? Metadata { get; set; }
}
