using System;
class Program
{
    public static void Main(string[] args)
    {
        double openingBalance, deposits, withdrawls, availableBalance;

        Console.WriteLine("Enter the Opening Balance");
        while(!double.TryParse(Console.ReadLine(), out openingBalance) || openingBalance < 0)
        {
            Console.WriteLine("Invalid Input!");
            Console.WriteLine("Enter the Opening Balance again! ");
        }

        Console.WriteLine("Enter the Deposits ");
        while(!double.TryParse(Console.ReadLine(), out deposits) || deposits < 0)
        {
            Console.WriteLine("Invalid Input!");
            Console.WriteLine("Enter the Deposits again! ");
        }

        Console.WriteLine("Enter the Withdrawls ");
        while(!double.TryParse(Console.ReadLine(), out withdrawls) || withdrawls < 0)
        {
            Console.WriteLine("Invalid Input!");
            Console.WriteLine("Enter the Withdrawls again! ");
        }
        
        availableBalance = openingBalance + deposits ;
        if(withdrawls > availableBalance)
            Console.WriteLine("Withdrawl amount cannot be greate than available balance");
        else
        {
            double finalBalance = availableBalance - withdrawls;
            Console.WriteLine($"Updated balance = {finalBalance}");
        }
    }
}