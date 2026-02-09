public class MenuItem
{
    public string ItemName { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public bool isVegetarian { get; set; }
}

public class MenuManager
{
    public static List<MenuItem> menuItems=new();
    public void AddMenuItem(string name, string category, double price, bool isVeg)
    {
        if (price <= 0)
        {
            System.Console.WriteLine("Item Not Added. Price should be more than 0.");
            return;
        }
        MenuItem menuItem=new MenuItem
        {
          ItemName=name,
          Category=category,
          Price=price,
          isVegetarian=isVeg
        };
        menuItems.Add(menuItem);
        System.Console.WriteLine("Item Added Successfully");
    }

    public Dictionary<string, List<MenuItem>> GroupItemsByCategory()
    {
        return menuItems.GroupBy(item=>item.Category).ToDictionary(g=>g.Key,g=>g.ToList());
    }

    public List<MenuItem> GetVegetarianItems()
    {
        return menuItems.Where(s=>s.isVegetarian==true).ToList();
    }

    public double CalculateAveragePriceByCategory(string category)
    {
        return menuItems.Where(m=> m.Category==category).Average(m=>m.Price);
    }
}

class Program
{
    static void Main()
    {
        MenuManager manager = new MenuManager();
        string choice;

        do
        {
            Console.WriteLine("\n--- Restaurant Menu Management ---");
            Console.WriteLine("1. Add Menu Item");
            Console.WriteLine("2. Display Menu by Category");
            Console.WriteLine("3. Show Vegetarian Menu");
            Console.WriteLine("4. Calculate Average Price by Category");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");

            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Item Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Category (Appetizer/Main Course/Dessert): ");
                    string category = Console.ReadLine();

                    Console.Write("Price: ");
                    double price = double.Parse(Console.ReadLine());

                    Console.Write("Is Vegetarian (true/false): ");
                    bool isVeg = bool.Parse(Console.ReadLine());

                    manager.AddMenuItem(name, category, price, isVeg);
                    break;

                case "2":
                    var grouped = manager.GroupItemsByCategory();
                    foreach (var c in grouped)
                    {
                        Console.WriteLine($"\n{c.Key}:");
                        foreach (var item in c.Value)
                        {
                            Console.WriteLine($"{item.ItemName} - ₹{item.Price} - {(item.isVegetarian ? "Veg" : "Non-Veg")}");
                        }
                    }
                    break;

                case "3":
                    var vegItems = manager.GetVegetarianItems();
                    Console.WriteLine("\nVegetarian Menu:");
                    foreach (var item in vegItems)
                    {
                        Console.WriteLine($"{item.ItemName} ({item.Category}) - ₹{item.Price}");
                    }
                    break;

                case "4":
                    Console.Write("Enter category: ");
                    string cat = Console.ReadLine();
                    Console.WriteLine("Average Price: ₹" + manager.CalculateAveragePriceByCategory(cat));
                    break;

                case "5":
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

        } while (choice != "5");
    }
}