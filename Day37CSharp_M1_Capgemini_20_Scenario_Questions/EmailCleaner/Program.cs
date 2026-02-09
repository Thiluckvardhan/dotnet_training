using System.Text;

namespace EmailCleaner
{
    public class Program
    {
        public static void Main()
        {
            System.Console.WriteLine("Enter Your Email: ");
            string? email=Console.ReadLine();
            if (string.IsNullOrEmpty(email))
            {
                System.Console.WriteLine("Email cannot be Empty.");
                return;
            }
            // var splitedemail=email.Split(' ');
            // StringBuilder updated=new();
            // foreach(var item in splitedemail)
            // {
            //     email=item.Trim();
            //     updated.Append(email);
            // }
            // string replaced=updated.ToString();
            // replaced=replaced.ToLower();
            // replaced=replaced.Replace("gmail.com","company.com");
            email=email.Replace(" ","").ToLower().Replace("gmail.com","company.com");
            System.Console.WriteLine(email);
        }
    }
}

