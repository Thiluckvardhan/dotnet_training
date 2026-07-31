using CartApi.Models;
using CartApi.Models.Contracts;

namespace CartApi.Services;

public class CartService
{
    private readonly object _sync = new();
    private readonly List<CartItem> _items = [];

    public void ProductSelect(ProductSelected selected)
    {
        lock (_sync)
        {
            var existing = _items.FirstOrDefault(i => i.ProductId == selected.ProductId);
            if (existing is null)
            {
                _items.Add(new CartItem
                {
                    ProductId = selected.ProductId,
                    Name = selected.Name,
                    Price = selected.Price,
                    Quantity = selected.Quantity
                });
                return;
            }

            existing.Quantity += selected.Quantity;
            existing.Price = selected.Price;
            existing.Name = selected.Name;
        }
    }

    public IReadOnlyCollection<CartItem> GetItems()
    {
        lock (_sync)
        {
            return _items
                .Select(i => new CartItem
                {
                    ProductId = i.ProductId,
                    Name = i.Name,
                    Price = i.Price,
                    Quantity = i.Quantity
                })
                .ToList();
        }
    }

    public CartCheckedOut Checkout()
    {
        lock (_sync)
        {
            var order = new CartCheckedOut
            {
                OrderId = Guid.NewGuid().ToString("N"),
                Items = _items.Select(i => new CartCheckedOutItem
                {
                    ProductId = i.ProductId,
                    Name = i.Name,
                    Price = i.Price,
                    Quantity = i.Quantity
                }).ToList(),
                TotalAmount = _items.Sum(i => i.LineTotal),
                CheckedOutAtUtc = DateTime.UtcNow
            };

            _items.Clear();
            return order;
        }
    }
}
