namespace BankingWithdrawalValidation
{
    public class BankException : Exception
    {
        public BankException(string message) : base(message)
        {
        }
    }

    public class BankAccount
    {
        public static void Main()
        {
            int balance = 10000;

            try
            {
                Console.WriteLine("Enter withdrawal amount:");

                int amount;
                if (!int.TryParse(Console.ReadLine(), out amount))
                {
                    throw new FormatException("Invalid input. Please enter a number.");
                }

                if (amount <= 0)
                {
                    throw new BankException("Withdrawal amount must be greater than zero.");
                }

                if (amount > balance)
                {
                    throw new BankException("Insufficient balance for withdrawal.");
                }

                balance -= amount;
                Console.WriteLine($"Withdrawal successful. Remaining balance: {balance}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (BankException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Transaction logged.");
            }
        }
    }
}
