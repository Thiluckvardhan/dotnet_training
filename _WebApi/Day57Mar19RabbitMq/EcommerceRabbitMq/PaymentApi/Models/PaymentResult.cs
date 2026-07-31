namespace PaymentApi.Models;

public class PaymentResult
{
    public string OrderId { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public DateTime ProcessedAtUtc { get; set; }
}
