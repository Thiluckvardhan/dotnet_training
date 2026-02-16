using System;
using System.Collections.Generic;
using System.Linq;

public interface IProduct
{
    int Id { get; }
    string Name { get; }
    decimal Price { get; }
    Category Category { get; }
}

public enum Category
{
    Electronics,
    Clothing,
    Books,
    Groceries
}

public class ProductRepository<T> where T : class, IProduct
{
    private List<T> _products = new List<T>();

    public void AddProduct(T product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));

        if (_products.Any(p => p.Id == product.Id))
            throw new Exception($"❌ Product with ID {product.Id} already exists.");

        if (product.Price <= 0)
            throw new Exception("❌ Price must be greater than zero.");

        if (string.IsNullOrWhiteSpace(product.Name))
            throw new Exception("❌ Product name cannot be empty.");

        _products.Add(product);

        Console.WriteLine($"✔ Added: {product.Name} | ID: {product.Id} | Price: {product.Price}");
    }

    public IEnumerable<T> FindProducts(Func<T, bool> predicate)
    {
        return _products.Where(predicate);
    }

    public decimal CalculateTotalValue()
    {
        return _products.Sum(p => p.Price);
    }

    public List<T> GetAll() => _products;
}

public class ElectronicProduct : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category => Category.Electronics;
    public int WarrantyMonths { get; set; }
    public string Brand { get; set; }
}

public class DiscountedProduct<T> where T : IProduct
{
    private readonly T _product;
    private readonly decimal _discountPercentage;

    public DiscountedProduct(T product, decimal discountPercentage)
    {
        if (discountPercentage < 0 || discountPercentage > 100)
            throw new ArgumentException("Discount must be between 0 and 100.");

        _product = product;
        _discountPercentage = discountPercentage;
    }

    public decimal DiscountedPrice =>
        _product.Price * (1 - _discountPercentage / 100);

    public override string ToString()
    {
        return $"Product: {_product.Name} | Original: {_product.Price} | Discount: {_discountPercentage}% | Final: {DiscountedPrice}";
    }
}

public class InventoryManager
{
    public void ProcessProducts<T>(IEnumerable<T> products) where T : IProduct
    {
        Console.WriteLine("\n========== PRODUCT LIST ==========");

        foreach (var p in products)
            Console.WriteLine($"Product: {p.Name} | Price: {p.Price} | Category: {p.Category}");

        var mostExpensive = products.OrderByDescending(p => p.Price).First();
        Console.WriteLine($"\n⭐ Most Expensive Product: {mostExpensive.Name} ({mostExpensive.Price})");

        Console.WriteLine("\n========== GROUPED BY CATEGORY ==========");
        var grouped = products.GroupBy(p => p.Category);

        foreach (var group in grouped)
        {
            Console.WriteLine($"\nCategory: {group.Key}");
            foreach (var p in group)
                Console.WriteLine($" - {p.Name} ({p.Price})");
        }

        Console.WriteLine("\n========== DISCOUNT (Electronics > 500) ==========");
        foreach (var p in products.Where(p => p.Category == Category.Electronics && p.Price > 500))
        {
            var discounted = new DiscountedProduct<T>(p, 10);
            Console.WriteLine(discounted);
        }
    }

    public void UpdatePrices<T>(List<T> products, Func<T, decimal> priceAdjuster)
        where T : IProduct
    {
        
        Console.WriteLine("\n========== BULK PRICE UPDATE ==========");

        foreach (var product in products)
        {
            try
            {
                var newPrice = priceAdjuster(product);

                if (product is ElectronicProduct ep)
                    ep.Price = newPrice;

                Console.WriteLine($"Updated: {product.Name} → {newPrice}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠ Failed updating {product.Name}: {ex.Message}");
            }
        }
    }
}

public class Program
{
    public static void Main()
    {
        ProductRepository<ElectronicProduct> repo = new ProductRepository<ElectronicProduct>();

        var products = new List<ElectronicProduct>
        {
            new ElectronicProduct { Id = 1, Name = "Laptop", Price = 800, Brand = "Dell", WarrantyMonths = 24 },
            new ElectronicProduct { Id = 2, Name = "Mobile", Price = 600, Brand = "Samsung", WarrantyMonths = 12 },
            new ElectronicProduct { Id = 3, Name = "Headphones", Price = 150, Brand = "Sony", WarrantyMonths = 6 },
            new ElectronicProduct { Id = 4, Name = "Monitor", Price = 300, Brand = "LG", WarrantyMonths = 18 },
            new ElectronicProduct { Id = 5, Name = "TV", Price = 1200, Brand = "Sony", WarrantyMonths = 36 }
        };

        Console.WriteLine("========== ADDING PRODUCTS ==========");
        foreach (var p in products)
        {
            try
            {
                repo.AddProduct(p);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine("\n========== SONY PRODUCTS ==========");
        var sonyProducts = repo.FindProducts(p => p.Brand == "Sony");
        foreach (var p in sonyProducts)
            Console.WriteLine($"{p.Name} - {p.Price}");

        Console.WriteLine($"\n💰 Total Inventory Value (Before Update): {repo.CalculateTotalValue()}");

        Console.WriteLine("\n========== SAMPLE DISCOUNT ==========");
        var discounted = new DiscountedProduct<ElectronicProduct>(products[0], 10);
        Console.WriteLine(discounted);

        InventoryManager manager = new InventoryManager();
        manager.ProcessProducts(products);

        manager.UpdatePrices(products, p => p.Price * 1.05m);

        Console.WriteLine($"\n📈 Total Inventory Value (After 5% Increase): {repo.CalculateTotalValue()}");
    }
}
