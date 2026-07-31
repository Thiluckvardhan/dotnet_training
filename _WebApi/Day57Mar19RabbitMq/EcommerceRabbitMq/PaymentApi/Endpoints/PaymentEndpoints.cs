using PaymentApi.Services;

namespace PaymentApi.Endpoints;

public static class PaymentEndpoints
{
    public static IEndpointRouteBuilder MapPaymentEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/payments", (PaymentService paymentService) => Results.Ok(paymentService.GetAll()));

        app.MapGet("/payments/{orderId}", (string orderId, PaymentService paymentService) =>
        {
            var payment = paymentService.GetByOrderId(orderId);
            return payment is null ? Results.NotFound() : Results.Ok(payment);
        });

        return app;
    }
}
