using System.Collections.Concurrent;
using ProductApi.Models;

namespace ProductApi.Services;

public class ProductService
{
    private readonly ConcurrentDictionary<int, Product> _products = new();

    public ProductService()
    {
        var seedProducts = new[]
        {
            new Product { Id = 1, Name = "Laptop", Price = 75000m },
            new Product { Id = 2, Name = "Smartphone", Price = 35000m },
            new Product { Id = 3, Name = "Headphones", Price = 2500m },
            new Product { Id = 4, Name = "Keyboard", Price = 1800m },
            new Product { Id = 5, Name = "Mouse", Price = 900m },
            new Product { Id = 6, Name = "Monitor", Price = 12000m },
            new Product { Id = 7, Name = "Webcam", Price = 2200m },
            new Product { Id = 8, Name = "Speaker", Price = 3200m },
            new Product { Id = 9, Name = "External SSD", Price = 6800m },
            new Product { Id = 10, Name = "USB Hub", Price = 1100m }
        };

        foreach (var product in seedProducts)
        {
            _products[product.Id] = product;
        }
    }

    public Product Create(Product product)
    {
        _products[product.Id] = product;
        return product;
    }

    public IReadOnlyCollection<Product> GetAll()
    {
        return _products.Values.OrderBy(p => p.Id).ToList();
    }

    public Product? GetById(int id)
    {
        return _products.TryGetValue(id, out var product) ? product : null;
    }

    public bool UpdatePrice(int id, decimal price)
    {
        if (!_products.TryGetValue(id, out var product))
        {
            return false;
        }

        product.Price = price;
        return true;
    }
}
