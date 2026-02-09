using System;

class FileUpload
{
    static void Main()
    {
        string fileName = "report.exe";
        int fileSize = 8;

        try
        {
            if (!fileName.EndsWith(".pdf"))
            {
                throw new FormatException("Invalid file extension");
            }

            if (fileSize > 5)
            {
                throw new ArgumentOutOfRangeException("File size exceeds limit");
            }

            Console.WriteLine("File uploaded successfully");
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
