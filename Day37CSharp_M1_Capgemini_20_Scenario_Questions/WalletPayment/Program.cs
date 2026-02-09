namespace WalletPayment
{
    public class Program
    {
        public static bool MakePayment(ref double WalletBalance,double Amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid amount");
                return false;
            }
            if (Amount > WalletBalance)
            {
                System.Console.WriteLine("Amount cannot be deducted as Balance is less than amount");
                return false;
            }
            else
            {
                WalletBalance-=Amount;
                System.Console.WriteLine("Balance Deducted Successfully");
            }
            return true;
        }
        public static void Main()
        {
            System.Console.Write("Enter your Wallet Balance: ");
            if(!double.TryParse(Console.ReadLine(),out double walletBalance))
            {
                System.Console.WriteLine("Please only Enter numbers as input");
                return;
            }
            System.Console.Write("Enter Deduction Amount: ");
            if(!double.TryParse(Console.ReadLine(),out double amount))
            {
                System.Console.WriteLine("Please only Enter numbers as input");
                return;
            }
            if(Program.MakePayment(ref walletBalance,amount))
            {
                System.Console.WriteLine($"Updated Balance is : {walletBalance}");
            }
        }
    }
}