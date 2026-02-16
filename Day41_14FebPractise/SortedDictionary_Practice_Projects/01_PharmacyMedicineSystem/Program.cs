using System;
using Domain;
using Exceptions;
using Services;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MedicineUtility service = new();
            try
            {
                while (true)
                {
                    Console.WriteLine("1. Display");
                    Console.WriteLine("2. Add");
                    Console.WriteLine("3. Update");
                    Console.WriteLine("4. Exit");

                    // TODO: Read user choice
                    Console.Write("\nEnter your Choice: ");
                    int choice = int.Parse(Console.ReadLine()); // TODO

                    switch (choice)
                    {
                        case 1:
                            // TODO: Display data
                            SortedDictionary<int, List<Medicine>> data = service.GetAll();
                            if (data.Count==0)
                            {
                                System.Console.WriteLine("No Medicines to display");
                            }
                            foreach (var item in data)
                            {
                                System.Console.WriteLine($"The Medicines Expire in {item.Key}");
                                foreach (var med in item.Value)
                                {
                                    System.Console.WriteLine($"\t{med.MedicineId} {med.Name} {med.Price}");
                                }
                            }
                            break;
                        case 2:
                            Console.Write("Enter Medicine Id: ");
                            string id = Console.ReadLine();

                            Console.Write("Enter Medicine Name: ");
                            string name = Console.ReadLine();

                            Console.Write("Enter Price: ");
                            double price = double.Parse(Console.ReadLine());

                            Console.Write("Enter Expiry Year: ");
                            int year = int.Parse(Console.ReadLine());
                            Medicine medicine = new Medicine
                            {
                                MedicineId = id,
                                Name = name,
                                Price = price,
                                ExpiryYear = year
                            };
                            service.AddMedicine(medicine);
                            Console.WriteLine("Medicine Added Successfully");
                            break;
                        case 3:
                            Console.Write("Enter Medicine Id to Update: ");
                            string updateId = Console.ReadLine();
                            Console.Write("Enter New Price: ");
                            double newPrice = double.Parse(Console.ReadLine());
                            service.UpdateMedicinePrice(updateId, newPrice);
                            Console.WriteLine("Medicine Price Updated Successfully");
                            break;
                        case 4:
                            System.Console.WriteLine("Thank You");
                            return;
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                }
            }
            catch (DuplicateMedicineException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (InvalidExpiryYearException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (InvalidPriceException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (MedicineNotFoundException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}
