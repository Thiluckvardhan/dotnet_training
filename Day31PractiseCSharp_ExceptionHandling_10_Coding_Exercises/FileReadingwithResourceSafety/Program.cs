using System;
using System.IO;

public class FileErrorException: Exception
{
    public FileErrorException(string message): base(message){ }
}
class FileReader
{
    static void Main()
    {
        Console.WriteLine("Give File Path:");
        string? filePath = Console.ReadLine();

        StreamReader streamReader = null;

        try
        {
            streamReader = new StreamReader(filePath);
            string content = streamReader.ReadToEnd();
            Console.WriteLine(content);
        }
        catch(FileNotFoundException)
        {
            System.Console.WriteLine($"File not Found");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Access Not Granted");
        }
        finally
        {
            if (streamReader != null)
                streamReader.Close();
        }
    }
}
