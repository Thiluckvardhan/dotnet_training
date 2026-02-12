namespace GmailValidation
{
    public class Program
    {
        public static void Main()
        {
            System.Console.WriteLine("Enter a Gmail");
            string gmail = Console.ReadLine();
            if (string.IsNullOrEmpty(gmail))
            {
                System.Console.WriteLine("gmail cannot be empty");
                return;
            }
            string[] strings = gmail.Split('@');

            if (strings.Length != 2)
            {
                System.Console.WriteLine("Invalid Gmail");
                return;
            }
            bool isGmail = true;
            bool prevDot = false;
            List<char> inValidChars = new List<char> { '_', '&', '=', '+', ',', '<', '>', '!', '\'', '-', ' ' };
            foreach (char letter in strings[0])
            {
                if (prevDot && letter == '.')
                {
                    isGmail = false;
                    break;
                }
                if (inValidChars.Contains(letter) || !(char.IsAsciiLetterOrDigit(letter) || letter == '.'))
                {
                    isGmail = false;
                    break;
                }
                prevDot = (letter=='.');
            }
            if (strings[1] != "gmail.com")
            {
                isGmail = false;
            }
            if (isGmail)
            {
                System.Console.WriteLine("Valid Gmail");
            }
            else
            {
                System.Console.WriteLine("Invalid Gmail");
            }
        }
    }
}