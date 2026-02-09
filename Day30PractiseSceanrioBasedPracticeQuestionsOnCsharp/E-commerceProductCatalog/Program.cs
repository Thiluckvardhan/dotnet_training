public class Product
{
    public string ProductCode { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public int StockQuantity { get; set; }
}

public class InventoryManager
{
    public List<Product> products = new();
    private int productCount = 0;
    public void AddProduct(string name, string category, double price, int stock)
    {

        productCount++;
        Product product = new Product
        {
            ProductCode = "P" + productCount.ToString("D3"),
            ProductName = name,
            Category = category,
            Price = price,
            StockQuantity = stock
        };
        products.Add(product);
    }
    public SortedDictionary<string, List<Product>> GroupProductsByCategory()
    {
        return new SortedDictionary<string, List<Product>>
        (
            products.GroupBy(p => p.Category).ToDictionary(g => g.Key, g => g.ToList())
        ); // passing dictonary as a argument to constructor of sorteddictonary 
    }
    public bool UpdateStock(string productCode, int quantity)
    {
        Product? product = products.FirstOrDefault(p => p.ProductCode == productCode);
        if (product == null) return false;
        if (product.StockQuantity < quantity) return false;

        product.StockQuantity -= quantity;
        return true;
    }

    public List<Product> GetProductsBelowPrice(double maxPrice)
    {
        return products.Where(p => p.Price < maxPrice).ToList();
    }

    public Dictionary<string, int> GetCategoryStockSummary()
    {
        Dictionary<string, int> result = new();
        foreach (Product product in products)
        {
            result.TryAdd(product.Category, 0);
            result[product.Category] += product.StockQuantity;
        }
        return result;
    }
}

public class Program
{
    public static void Main()
    {
        InventoryManager manager = new();

        while (true)
        {
            Console.WriteLine("\n--- E-Commerce Product Catalog ---");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Display Products by Category");
            Console.WriteLine("3. Update Stock After Sale");
            Console.WriteLine("4. Find Products Below Price");
            Console.WriteLine("5. Inventory Summary");
            Console.WriteLine("6. Exit");
            Console.Write("Choose option: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Product Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Category (Electronics/Clothing/Books): ");
                    string category = Console.ReadLine();

                    Console.Write("Price: ");
                    double price = double.Parse(Console.ReadLine());

                    Console.Write("Stock Quantity: ");
                    int stock = int.Parse(Console.ReadLine());

                    manager.AddProduct(name, category, price, stock);
                    Console.WriteLine("Product Added Successfully");
                    break;

                case 2:
                    var grouped = manager.GroupProductsByCategory();
                    foreach (var cat in grouped)
                    {
                        Console.WriteLine("\nCategory: " + cat.Key);
                        foreach (var p in cat.Value)
                            Console.WriteLine($"{p.ProductCode} | {p.ProductName} | ₹{p.Price} | Stock: {p.StockQuantity}");
                    }
                    break;

                case 3:
                    Console.Write("Enter Product Code: ");
                    string code = Console.ReadLine();

                    Console.Write("Quantity Sold: ");
                    int qty = int.Parse(Console.ReadLine());

                    Console.WriteLine(manager.UpdateStock(code, qty)
                        ? "Stock Updated"
                        : "Insufficient Stock or Invalid Product");
                    break;

                case 4:
                    Console.Write("Enter Max Price: ");
                    double max = double.Parse(Console.ReadLine());

                    var filtered = manager.GetProductsBelowPrice(max);
                    foreach (var p in filtered)
                        Console.WriteLine($"{p.ProductCode} | {p.ProductName} | ₹{p.Price}");
                    break;

                case 5:
                    var summary = manager.GetCategoryStockSummary();
                    foreach (var s in summary)
                        Console.WriteLine($"{s.Key} : Total Stock = {s.Value}");
                    break;

                case 6:
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }
}