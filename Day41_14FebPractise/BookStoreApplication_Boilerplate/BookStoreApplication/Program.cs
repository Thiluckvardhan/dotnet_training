using System;

namespace BookStoreApplication
{
    public class InvalidBookDataException : Exception
    {
        public InvalidBookDataException(string message):base(message){}
    }
    class Program
    {
        static void Main(string[] args)
        {
            // TODO:
            // 1. Read initial input
            // Format: BookID Title Price Stock
            string[] split=Console.ReadLine().Split(" ");
            Book book = new Book
            {
                Id=split[0],
                Title=split[1],
                Price=int.Parse(split[2]),
                Stock=int.Parse(split[3])
            };

            BookUtility utility = new BookUtility(book);
            while (true)
            {
                // TODO:
                // Display menu:
                Console.WriteLine("1 -> Display book details");
                Console.WriteLine("2 -> Update book price");
                Console.WriteLine("3 -> Update book stock");
                Console.WriteLine("4 -> Exit");
                
                try
                {
                int choice = int.Parse(Console.ReadLine()); // TODO: Read user choice

                switch (choice)
                {
                    case 1:
                        utility.GetBookDetails();
                        break;

                    case 2:
                        // TODO:
                        // Read new price
                        // Call UpdateBookPrice()
                        int newPrice=int.Parse(Console.ReadLine());
                        utility.UpdateBookPrice(newPrice);
                        break;

                    case 3:
                        // TODO:
                        // Read new stock
                        // Call UpdateBookStock()
                        int newStock=int.Parse(Console.ReadLine());
                        utility.UpdateBookStock(newStock);
                        break;

                    case 4:
                        Console.WriteLine("Thank You");
                        return;

                    default:
                        // TODO: Handle invalid choice
                        System.Console.WriteLine("Only Enter 1 or 2 or 3 or 4");
                        break;
                }
                }
                catch(InvalidBookDataException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                catch(Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
