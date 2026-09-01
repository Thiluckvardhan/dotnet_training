using System;
interface IBillCaclculator
{
    double CalculateBill(double units);
}
class ResidentCustomer: IBillCaclculator
{
    public double CalculateBill(double units)
    {
        double rate = 5.0;
        double fixedCharge = 100.0;
        return rate*units+fixedCharge;
    }
}
class CommercialCustomer: IBillCaclculator
{
    public double CalculateBill(double units)
    {
        double rate = 10.0;
        double fixedCharge = 500.0;
        return rate*units+fixedCharge;
    }
}
class Program
{
    public static void Main(string[] args)
    {
        double units;
        int customerType;
        Console.WriteLine("Enter the customer type (1 for Resident, 2 for Commercial): ");
        while (!int.TryParse(Console.ReadLine(), out customerType)||(customerType != 1 && customerType != 2))
        {
            Console.WriteLine("Invalid Customer Type!");
            Console.Write("Enter Customer Type: ");
        }
        Console.WriteLine("Enter the number of units consumed: ");
        while (!double.TryParse(Console.ReadLine(), out units) || units < 0)
        {
            Console.WriteLine("Invalid Input!");
            Console.Write("Enter the number of units consumed: ");
        }

        IBillCaclculator billCalculator;
        if (customerType == 1)
        {
            billCalculator = new ResidentCustomer();
        }
        else
        {
            billCalculator = new CommercialCustomer();
        }
        double totalBill = billCalculator.CalculateBill(units);
        Console.WriteLine($"Total Bill Amount: {totalBill:F2}");
    }
}