namespace PaymentApi.Models.Contracts;

public class CartCheckedOut
{
    public string OrderId { get; set; } = string.Empty;
    public List<CartCheckedOutItem> Items { get; set; } = [];
    public decimal TotalAmount { get; set; }
    public DateTime CheckedOutAtUtc { get; set; }
    public Dictionary<string, string>? Metadata { get; set; }
}

public class CartCheckedOutItem
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
