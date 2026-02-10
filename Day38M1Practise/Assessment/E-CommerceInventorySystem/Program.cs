using System;
using System.Collections.Generic;
using System.Linq;

// Base product interface
public interface IProduct
{
    int Id { get; }
    string Name { get; }
    decimal Price { get; }
    Category Category { get; }
}

public enum Category { Electronics, Clothing, Books, Groceries }

// 1. Create a generic repository for products
public class ProductRepository<T> where T : class, IProduct
{
    private List<T> _products = new List<T>();

    // TODO: Implement method to add product with validation
    public void AddProduct(T product)
    {
        // Rule: Product ID must be unique
        // Rule: Price must be positive
        // Rule: Name cannot be null or empty
        // Add to collection if validation passes
        if (_products.Any(p => p.Id == product.Id))
        {
            throw new Exception($"Cannot Add Product {product.Name} as product Id{product.Id} already Exists");
        }
        if (product.Price < 0)
        {
            throw new Exception("Cannot Add Product as Price is not Postive.");
        }
        if (string.IsNullOrEmpty(product.Name))
        {
            throw new Exception("Cannot Add Product as Name is NUll Or Empty");
        }
        _products.Add(product);
        System.Console.WriteLine("Product Added Successfully");
    }

    // TODO: Create method to find products by predicate
    public IEnumerable<T> FindProducts(Func<T, bool> predicate)
    {
        // Should return filtered products
        return _products.Where(predicate);
    }

    // TODO: Calculate total inventory value
    public decimal CalculateTotalValue()
    {
        // Return sum of all product prices
        decimal total = _products.Sum(product => product.Price);
        return total;
    }
}

// 2. Specialized electronic product
public class ElectronicProduct : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category => Category.Electronics;
    public int WarrantyMonths { get; set; }
    public string Brand { get; set; }
}

// 3. Create a discounted product wrapper
public class DiscountedProduct<T> where T : IProduct
{
    private T _product;
    private decimal _discountPercentage;

    public DiscountedProduct(T product, decimal discountPercentage)
    {
        // TODO: Initialize with validation
        // Discount must be between 0 and 100
        _product = product;
        if (discountPercentage >= 0 && discountPercentage <= 100)
        {
            _discountPercentage = discountPercentage;
        }
        else
        {
            _discountPercentage = 0;
        }
    }

    // TODO: Implement calculated price with discount
    public decimal DiscountedPrice => _product.Price * (1 - _discountPercentage / 100);

    // TODO: Override ToString to show discount details
    public override string ToString()
    {
        return $"{DiscountedPrice}";
    }
}

// 4. Inventory manager with constraints
public class InventoryManager
{
    // TODO: Create method that accepts any IProduct collection
    public void ProcessProducts<T>(IEnumerable<T> products) where T : IProduct
    {
        // a) Print all product names and prices
        // b) Find the most expensive product
        // c) Group products by category
        // d) Apply 10% discount to Electronics over $500
        decimal expensiveProduct = 0.0m;
        string expensiveProductName = "";
        foreach (var product in products)
        {
            System.Console.WriteLine($"{product.Name}   {product.Price}");
            if (expensiveProduct < product.Price)
            {
                expensiveProduct = product.Price;
                expensiveProductName = product.Name;
            }
        }
        System.Console.WriteLine($"The costliest Product is {expensiveProductName}");
        var grouped = products.GroupBy(product => product.Category);
        foreach (var group in grouped)
        {
            Console.WriteLine($"\nCategory: {group.Key}");
            foreach (var p in group)
                Console.WriteLine($"{p.Name}");
        }
        Console.WriteLine("\nDiscounted Prices (Electronics > 500):");
        foreach (var product in products)
        {
            if (product.Category == Category.Electronics && product.Price > 500m)
            {
                if (product is ElectronicProduct p)
                    p.Price *= 0.9m;
            }
        }
    }

    // TODO::Implement bulk price update with delegate
    public void UpdatePrices<T>(List<T> products, Func<T, decimal> priceAdjuster)
        where T : IProduct
    {
        // Apply priceAdjuster to each product
        // Handle exceptions gracefully
    }
}

// 5. TEST SCENARIO: Your tasks:
// a) Implement all TODO methods with proper error handling
// b) Create a sample inventory with at least 5 products
// c) Demonstrate:
//    - Adding products with validation
//    - Finding products by brand (for electronics)
//    - Applying discounts
//    - Calculating total value before/after discount
//    - Handling a mixed collection of different product types
public class Program
{
    public static void Main()
    {
        // Repository
        ProductRepository<ElectronicProduct> electronicRepo = new ProductRepository<ElectronicProduct>();
        // Sample products
        var product1 = new ElectronicProduct { Id = 1, Name = "Laptop", Price = 800, Brand = "Dell", WarrantyMonths = 24 };
        var product2 = new ElectronicProduct { Id = 2, Name = "Mobile", Price = 600, Brand = "Samsung", WarrantyMonths = 12 };
        var product3 = new ElectronicProduct { Id = 3, Name = "Headphones", Price = 150, Brand = "Sony", WarrantyMonths = 6 };
        var product4 = new ElectronicProduct { Id = 4, Name = "Monitor", Price = 300, Brand = "LG", WarrantyMonths = 18 };
        var product5 = new ElectronicProduct { Id = 5, Name = "TV", Price = 1200, Brand = "Sony", WarrantyMonths = 36 };

        var products = new List<ElectronicProduct>
        {
            product1, product2, product3, product4, product5
        };

        foreach (var p in products)
        {
            try
            {
                electronicRepo.AddProduct(p);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Find products by brand
        var sonyProducts = electronicRepo.FindProducts(p => p.Brand == "Sony");
        Console.WriteLine("Sony Products:");
        foreach (var p in sonyProducts)
            Console.WriteLine($"{p.Name} - {p.Price}");

        // Total value before discount
        Console.WriteLine($"Total Value Before Discount: {electronicRepo.CalculateTotalValue()}");

        // Discount example
        var discounted = new DiscountedProduct<ElectronicProduct>(product1, 10);
        Console.WriteLine($"Discounted Price of {product1.Name}: {discounted.DiscountedPrice}");

        // Inventory manager processing
        InventoryManager manager = new InventoryManager();
        manager.ProcessProducts(new List<ElectronicProduct> { product1, product2, product3, product4, product5 });

        // Bulk price update example
        // manager.UpdatePrices(
        //     new List<ElectronicProduct> { p1, p2, p3, p4, p5 },
        //     prod => prod.Price * 1.05m
        // );

        // Total value after update
        Console.WriteLine($"Total Value After Update: {electronicRepo.CalculateTotalValue()}");
    }
}

