using ProductApi.Messaging;
using ProductApi.Models;
using ProductApi.Models.Contracts;
using ProductApi.Services;

namespace ProductApi.Endpoints;

public static class ProductEndpoints
{
    public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/products", (Product product, ProductService productService) =>
        {
            if (product.Id <= 0 || string.IsNullOrWhiteSpace(product.Name) || product.Price < 0)
            {
                return Results.BadRequest("Provide valid product Id, Name, and non-negative Price.");
            }

            var created = productService.Create(product);
            return Results.Created($"/products/{created.Id}", created);
        });

        app.MapGet("/products", (ProductService productService) => Results.Ok(productService.GetAll()));

        app.MapGet("/products/{id:int}", (int id, ProductService productService) =>
        {
            var product = productService.GetById(id);
            return product is null ? Results.NotFound() : Results.Ok(product);
        });

        app.MapPut("/products/{id:int}/price", (int id, UpdatePriceRequest request, ProductService productService) =>
        {
            if (request.Price < 0)
            {
                return Results.BadRequest("Price cannot be negative.");
            }

            var updated = productService.UpdatePrice(id, request.Price);
            return updated ? Results.NoContent() : Results.NotFound();
        });

        app.MapPost("/products/{id:int}/select", (
            int id,
            ProductSelectionRequest request,
            ProductService productService,
            ProductEventPublisher publisher) =>
        {
            var product = productService.GetById(id);
            if (product is null)
            {
                return Results.NotFound();
            }

            if (request.Quantity <= 0)
            {
                return Results.BadRequest("Quantity must be greater than zero.");
            }

            var message = new ProductSelected
            {
                ProductId = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = request.Quantity,
                SelectedAtUtc = DateTime.UtcNow
            };

            publisher.PublishProductSelected(message);
            return Results.Accepted($"/products/{id}", message);
        });

        return app;
    }
}
