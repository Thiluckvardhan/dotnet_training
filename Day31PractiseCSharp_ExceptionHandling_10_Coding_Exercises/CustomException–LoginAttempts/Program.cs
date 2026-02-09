using System;

public class LimitException : Exception
{
    public LimitException(string message): base(message)
    {
        
    }
}
class LoginSystem
{
    static void Main()
    {
        int attempts = 0;
        // TODO
        // 1. Allow only 3 login attempts
        string password="ABCDE";
        string inputpassword=null;
        try
        {
        while (true)
        {
            if (attempts >= 3)
            {
        // 2. Create and throw custom exception after limit
                throw new LimitException("Password Attempt Limit reached");
            }
            System.Console.Write("Enter your Password: ");
            inputpassword=Console.ReadLine();
            attempts++;
            if (inputpassword == null)
            {
                continue;
            }
            if (password == inputpassword)
            {
                System.Console.WriteLine("Correct Password");
                break;
            }
        }
        }
        // 3. Handle exception and terminate application
        catch (LimitException ex)
        {
            System.Console.WriteLine($"{ex.Message}");
        }
        catch(Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}