using System.Text;
namespace PasswordMasking
{
    public class Program
    {
        public static void Main()
        {
            System.Console.Write("Enter your PassWord: ");
            string? password=Console.ReadLine();
            StringBuilder passwordHasher=new();
            if (string.IsNullOrEmpty(password))
            {
                System.Console.WriteLine("Password Cannot be Empty");
                return;
            }
            int length=password.Length;
            if(length<3)
            {
                System.Console.WriteLine("Password Length must not be less than 3.");
                return;
            }
            passwordHasher.Append(password[0]);
            for(int i = 1; i < length-1; i++)
            {
                passwordHasher.Append("*");
            }
            passwordHasher.Append(password[length-1]);
            System.Console.Write($"Your Masked Password is : {passwordHasher.ToString()}");
        }
    }
}