using System;

class DatabaseConnection
{
    static void Main()
    {
        // TODO:
        // 1. Open connection
        bool isConnected=false;
        try
        {
            System.Console.WriteLine("Opening DataBase Connection.");
            isConnected=true;

            throw new Exception("DataBase Operation Failure");
        }
        // 2. Simulate operation failure
        catch(Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        // 3. Ensure connection is closed properly
        finally
        {
            if (isConnected)
            {
                isConnected=false;
                System.Console.WriteLine("DataBase Connection Closed.");
            }
        }
    }
}