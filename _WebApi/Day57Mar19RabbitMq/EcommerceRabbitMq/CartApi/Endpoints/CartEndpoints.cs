using CartApi.Messaging;
using CartApi.Services;

namespace CartApi.Endpoints;

public static class CartEndpoints
{
    public static IEndpointRouteBuilder MapCartEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/cart", (CartService cartService) =>
        {
            var items = cartService.GetItems();
            var total = items.Sum(i => i.LineTotal);
            return Results.Ok(new { Items = items, TotalAmount = total });
        });

        app.MapPost("/cart/checkout", (CartService cartService, CartEventPublisher publisher) =>
        {
            var items = cartService.GetItems();
            if (items.Count == 0)
            {
                return Results.BadRequest("Cart is empty.");
            }

            var checkoutEvent = cartService.Checkout();
            publisher.PublishCartCheckedOut(checkoutEvent);
            return Results.Accepted($"/cart/checkout/{checkoutEvent.OrderId}", checkoutEvent);
        });

        return app;
    }
}
