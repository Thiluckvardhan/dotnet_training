using System;

class Controller
{
    static void Main()
    {
        // TODO:
        // Call Service method
        try
        {
        Service.Process();
        }
        catch(Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        // Handle exception here
    }
}

class Service
{
    public static void Process()
    {
        // TODO:
        // Call Repository method
        try
        {
            Repository.GetData();
        }
        // Catch, log and rethrow exception
        catch(Exception ex)
        {
            Console.WriteLine("Logging exception in Service layer");
            throw;
        }
    }
}

class Repository
{
    public static void GetData()
    {
        // TODO:
        // Throw an exception here
        throw new Exception("Data Not Found");
    }
}
