namespace Bank
{
    public class Program
    {
        public static void Main()
        {
            double balance = 5000;
            Console.WriteLine($"Your Account Balance {balance}");
            Console.Write("Enter the amount you want to deposit: ");
            if(!double.TryParse(Console.ReadLine(),out double deposit) || deposit<0)
            {
                Console.WriteLine("deposit cannot be Negative or only be numbers");
                return;
            }
            balance += deposit;
            Console.WriteLine("Deposit Successful");
            Console.WriteLine($"Balance : {balance}");
            Console.Write("Enter the amount you want to withdraw: ");
            if (!double.TryParse(Console.ReadLine(), out double withdraw) || withdraw < 0)
            {
                Console.WriteLine("withdraw cannot be Negative or only be numbers");
                return;
            }
            if(withdraw > balance)
            {
                Console.WriteLine("Withdraw not possible amount is greatet than balance");
            }
            else
            {
                balance -= withdraw;
                Console.WriteLine("Withdraw successful");
                Console.WriteLine($"Balance : {balance}");
            }
        }
    }
}