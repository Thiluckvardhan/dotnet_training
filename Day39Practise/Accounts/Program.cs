namespace Accounts
{
    public class BankAccount
    {
        public string? Name{get;set;}
        public double Balance{get;protected set;}

        public BankAccount(string name,double balance)
        {
            Name=name;
            Balance=balance;
            System.Console.WriteLine($"Account Added {Name}");
        }

        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Amount cannot be Added. Amount should be Positive");
            }
            Balance+=amount;
            System.Console.WriteLine("Deposit SuccessFull");
        }
        public void Withdraw(double amount)
        {
            if (amount > Balance)
            {
                throw new Exception("Withdraw not Possible As Withdraw Amount is Larger than Balance");
            }
            else if (amount <= 0)
            {
                throw new Exception("Amount cannot be Deducted. Amount should be Positive");
            }
            Balance-=amount;
            System.Console.WriteLine($"Withdrawl Successfull. Remaining Balance {Balance}");
        }
    }

    public class SavingAccount : BankAccount
    {
        public SavingAccount(string name,double balance) : base(name, balance)
        {
            
        }
        public double IntrestCalculation(double intrest)
        {
            if (intrest <= 0)
            {
                throw new Exception("Intrest Cannot be Calculated as its Not Positive");
            }
            return Balance+Balance*intrest/100;
        }
    }
    public class Program
    {
        public static void Main()
        {
            BankAccount bankAccount1=new("Thiluck",10000);
            try
            {
                bankAccount1.Deposit(5000);
                bankAccount1.Withdraw(2000);
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            SavingAccount savingAccount1=new("Vishwa",20000);
            try
            {
                savingAccount1.Deposit(5000);
                savingAccount1.Withdraw(2000);
                Console.WriteLine($"Calculated Intrest : {savingAccount1.IntrestCalculation(2)}");
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}