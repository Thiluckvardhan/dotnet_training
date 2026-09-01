using System;
class Program
{
    public static void Main(string[] args)
    {
        double price, discount;
        int quantity;
        Console.WriteLine("Enter the price of the item: ");
        while(!double.TryParse(Console.ReadLine(), out price) || price <0)
        {
            Console.WriteLine("Invalid Input");
            Console.WriteLine("Enter the price of the item again! : ");
        }

        Console.WriteLine("Enter the quantity of the item: ");
        while(!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
        {
            Console.WriteLine("Invalid Input");
            Console.WriteLine("Enter the quantity of the item again! : ");
        }

        Console.WriteLine("Enter the discount percentage: ");
        while(!double.TryParse(Console.ReadLine(), out discount) || discount < 0 || discount > 100)
        {
            Console.WriteLine("Invalid Input");
            Console.WriteLine("Enter the discount percentage again! : ");
        }

        double totalPrice = price * quantity;
        double discountAmount = totalPrice * (discount / 100);
        double finalPrice = totalPrice - discountAmount;

        totalPrice = Math.Round(totalPrice, 2);
        discountAmount = Math.Round(discountAmount, 2);
        finalPrice = Math.Round(finalPrice, 2);

        Console.WriteLine($"Total Price: {totalPrice}");
        Console.WriteLine($"Discount Amount: {discountAmount}");
        Console.WriteLine($"Final Price after Discount: {finalPrice}");
    }
}