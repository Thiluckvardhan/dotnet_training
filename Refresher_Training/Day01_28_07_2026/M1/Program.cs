namespace Retail_Store
{
    public class Program
    {
        public static  void Main()
        { 
            Console.WriteLine("Enter Price of the Item: ");
            if(!double.TryParse(Console.ReadLine(),out double Price) || Price<0)
            {
                Console.WriteLine("Enter only Positive Numbers");
                Console.WriteLine("Please Try Again");
                return;
            }
            Console.WriteLine("Enter Quantity Purchased: ");
            if(!int.TryParse(Console.ReadLine(),out int Quantity) || Quantity<0)
            {
                Console.WriteLine("Enter only Positive Numbers");
                Console.WriteLine("Please Try Again");
                return;
            }
            Console.WriteLine("Enter Discount Percentage: ");
            if(!double.TryParse(Console.ReadLine(),out double DiscountPercentage) || DiscountPercentage<0)
            {
                Console.WriteLine("Enter only Positive Numbers");
                Console.WriteLine("Please Try Again");
                return;
            }
            double Sub_total = Math.Round((Price * Quantity),2);
            double Discount_Amount = Math.Round(Sub_total * DiscountPercentage / 100,2);
            double Final_Amount = Math.Round(Sub_total - Discount_Amount,2);

            Console.WriteLine($"Sub Total: {Sub_total:F2}");
            Console.WriteLine($"Discount_Amount: {Discount_Amount:F2}");
            Console.WriteLine($"Final Amount: {Final_Amount:F2}");
        }
    }
}