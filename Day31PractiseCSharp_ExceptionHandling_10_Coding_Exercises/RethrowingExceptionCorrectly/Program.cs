using System;

class ExceptionRethrow
{
    static void Main()
    {
        try
        {
            ProcessData();
        }
        catch (Exception ex)
        {
            // TODO:
            // Handle final exception
            System.Console.WriteLine(ex.Message);
        }
    }

    static void ProcessData()
    {
        try
        {
            int.Parse("ABC");
        }
        catch (Exception)
        {
            // TODO:
            // Log exception
            Console.WriteLine("Logging exception in ProcessData");
            // Rethrow while preserving stack trace
            throw;
        }
    }
}
