namespace CartApi.Models.Contracts;

public class PaymentProcessed
{
    public string OrderId { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public DateTime ProcessedAtUtc { get; set; }
    public Dictionary<string, string>? Metadata { get; set; }
}
