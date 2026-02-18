using System;
using FlexibleInventorySystem_Practice.Services;
using FlexibleInventorySystem_Practice.Models;


namespace FlexibleInventorySystem_Practice
{
    /// <summary>
    /// TODO: Implement console user interface
    /// </summary>
    class Program
    {
        private static InventoryManager _inventory = new InventoryManager();

        static void Main(string[] args)
        {
            while (true)
            {
                DisplayMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProductMenu();
                        break;
                    case "2":
                        RemoveProductMenu();
                        break;
                    case "3":
                        UpdateQuantityMenu();
                        break;
                    case "4":
                        FindProductMenu();
                        break;
                    case "5":
                        ViewAllProductsMenu();
                        break;
                    case "6":
                        GenerateReportsMenu();
                        break;
                    case "7":
                        CheckLowStockMenu();
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Flexible Inventory System");
            Console.WriteLine("-------------------------");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Remove Product");
            Console.WriteLine("3. Update Quantity");
            Console.WriteLine("4. Find Product");
            Console.WriteLine("5. View All Products");
            Console.WriteLine("6. Generate Reports");
            Console.WriteLine("7. Check Low Stock");
            Console.WriteLine("8. Exit");
            Console.Write("Select an option: ");
        }

        static void AddProductMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Add Product");
            Console.WriteLine("1. Electronic");
            Console.WriteLine("2. Grocery");
            Console.WriteLine("3. Clothing");
            Console.Write("Select type: ");
            string typeChoice = Console.ReadLine();

            Product product = typeChoice switch
            {
                "1" => CreateElectronicProduct(),
                "2" => CreateGroceryProduct(),
                "3" => CreateClothingProduct(),
                _ => null
            };

            if (product == null)
            {
                Console.WriteLine("Invalid product type.");
                return;
            }

            bool added = _inventory.AddProduct(product);
            Console.WriteLine(added ? "Product added." : "Failed to add product.");
        }

        static void RemoveProductMenu()
        {
            Console.Write("Enter Product ID to remove: ");
            string productId = Console.ReadLine();
            bool removed = _inventory.RemoveProduct(productId);
            Console.WriteLine(removed ? "Product removed." : "Product not found.");
        }

        static void UpdateQuantityMenu()
        {
            Console.Write("Enter Product ID to update: ");
            string productId = Console.ReadLine();
            int newQuantity = ReadInt("Enter new quantity: ");
            bool updated = _inventory.UpdateQuantity(productId, newQuantity);
            Console.WriteLine(updated ? "Quantity updated." : "Product not found.");
        }

        static void FindProductMenu()
        {
            Console.Write("Enter Product ID to find: ");
            string productId = Console.ReadLine();
            Product product = _inventory.FindProduct(productId);
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.WriteLine("Product Details");
            Console.WriteLine(product.GetProductDetails());
        }

        static void ViewAllProductsMenu()
        {
            Console.WriteLine();
            Console.WriteLine(_inventory.GenerateInventoryReport());
        }

        static void GenerateReportsMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Reports");
            Console.WriteLine("1. Inventory Report");
            Console.WriteLine("2. Category Summary");
            Console.WriteLine("3. Value Report");
            Console.WriteLine("4. Expiry Report");
            Console.WriteLine("5. Back");
            Console.Write("Select report: ");
            string reportChoice = Console.ReadLine();

            switch (reportChoice)
            {
                case "1":
                    Console.WriteLine(_inventory.GenerateInventoryReport());
                    break;
                case "2":
                    Console.WriteLine(_inventory.GenerateCategorySummary());
                    break;
                case "3":
                    Console.WriteLine(_inventory.GenerateValueReport());
                    break;
                case "4":
                    int days = ReadInt("Enter days threshold: ");
                    Console.WriteLine(_inventory.GenerateExpiryReport(days));
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }

        static void CheckLowStockMenu()
        {
            int threshold = ReadInt("Enter low stock threshold: ");
            var lowStock = _inventory.GetLowStockProducts(threshold);

            if (lowStock.Count == 0)
            {
                Console.WriteLine("No low stock products.");
                return;
            }

            Console.WriteLine("Low Stock Products");
            foreach (var product in lowStock)
            {
                Console.WriteLine(product.GetProductDetails());
            }
        }

        static Product CreateElectronicProduct()
        {
            var product = new ElectronicProduct
            {
                Id = ReadNonEmptyString("Enter ID: "),
                Name = ReadNonEmptyString("Enter Name: "),
                Price = ReadDecimal("Enter Price: "),
                Quantity = ReadInt("Enter Quantity: "),
                Category = "Electronics",
                DateAdded = DateTime.Now,
                Brand = ReadNonEmptyString("Enter Brand: "),
                WarrantyMonths = ReadInt("Enter Warranty Months: "),
                Voltage = ReadNonEmptyString("Enter Voltage: "),
                IsRefurbished = ReadBool("Is Refurbished (y/n): ")
            };

            return product;
        }

        static Product CreateGroceryProduct()
        {
            var product = new GroceryProduct
            {
                Id = ReadNonEmptyString("Enter ID: "),
                Name = ReadNonEmptyString("Enter Name: "),
                Price = ReadDecimal("Enter Price: "),
                Quantity = ReadInt("Enter Quantity: "),
                Category = "Groceries",
                DateAdded = DateTime.Now,
                ExpiryDate = ReadDate("Enter Expiry Date (yyyy-MM-dd): "),
                IsPerishable = ReadBool("Is Perishable (y/n): "),
                Weight = ReadDouble("Enter Weight: "),
                StorageTemperature = ReadNonEmptyString("Enter Storage Temperature: ")
            };

            return product;
        }

        static Product CreateClothingProduct()
        {
            var product = new ClothingProduct
            {
                Id = ReadNonEmptyString("Enter ID: "),
                Name = ReadNonEmptyString("Enter Name: "),
                Price = ReadDecimal("Enter Price: "),
                Quantity = ReadInt("Enter Quantity: "),
                Category = "Clothing",
                DateAdded = DateTime.Now,
                Size = ReadNonEmptyString("Enter Size: "),
                Color = ReadNonEmptyString("Enter Color: "),
                Material = ReadNonEmptyString("Enter Material: "),
                Gender = ReadNonEmptyString("Enter Gender: "),
                Season = ReadNonEmptyString("Enter Season: ")
            };

            return product;
        }

        static string ReadNonEmptyString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string value = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(value))
                {
                    return value.Trim();
                }

                Console.WriteLine("Value cannot be empty.");
            }
        }

        static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string value = Console.ReadLine();
                if (int.TryParse(value, out int result))
                {
                    return result;
                }

                Console.WriteLine("Enter a valid integer.");
            }
        }

        static double ReadDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string value = Console.ReadLine();
                if (double.TryParse(value, out double result))
                {
                    return result;
                }

                Console.WriteLine("Enter a valid number.");
            }
        }

        static decimal ReadDecimal(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string value = Console.ReadLine();
                if (decimal.TryParse(value, out decimal result))
                {
                    return result;
                }

                Console.WriteLine("Enter a valid decimal number.");
            }
        }

        static DateTime ReadDate(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string value = Console.ReadLine();
                if (DateTime.TryParse(value, out DateTime result))
                {
                    return result;
                }

                Console.WriteLine("Enter a valid date.");
            }
        }

        static bool ReadBool(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string value = Console.ReadLine();
                if (string.Equals(value, "y", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                if (string.Equals(value, "n", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }

                Console.WriteLine("Enter y or n.");
            }
        }
    }
}