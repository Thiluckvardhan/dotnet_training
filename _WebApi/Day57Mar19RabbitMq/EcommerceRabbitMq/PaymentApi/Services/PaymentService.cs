using System.Collections.Concurrent;
using PaymentApi.Models;
using PaymentApi.Models.Contracts;

namespace PaymentApi.Services;

public class PaymentService
{
    private readonly ConcurrentDictionary<string, PaymentResult> _payments = new();

    public PaymentProcessed Process(CartCheckedOut checkout)
    {
        var processed = new PaymentProcessed
        {
            OrderId = checkout.OrderId,
            Status = "Success",
            Message = "Payment completed.",
            ProcessedAtUtc = DateTime.UtcNow
        };

        _payments[processed.OrderId] = new PaymentResult
        {
            OrderId = processed.OrderId,
            Status = processed.Status,
            Message = processed.Message,
            ProcessedAtUtc = processed.ProcessedAtUtc
        };

        return processed;
    }

    public IReadOnlyCollection<PaymentResult> GetAll()
    {
        return _payments.Values.OrderByDescending(p => p.ProcessedAtUtc).ToList();
    }

    public PaymentResult? GetByOrderId(string orderId)
    {
        return _payments.TryGetValue(orderId, out var result) ? result : null;
    }
}
