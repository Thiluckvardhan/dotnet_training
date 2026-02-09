using System;

class OrderProcessor
{
    static void Main()
    {
        int[] orders = { 101, -1, 103 };

        // TODO:
        // 1. Process each order
        // 2. Throw exception for invalid order ID
        // 3. Ensure one failure does not stop processing
        for(int i = 0; i < orders.Length; i++)
        {
            try
            {
                if(orders[i]<=0) throw new Exception("Order ID should not be negative.");
                else System.Console.WriteLine(orders[i]);
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}