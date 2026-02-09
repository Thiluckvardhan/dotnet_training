namespace MarksheetCalculation
{
    public class Program
    {
        public static void CalculateResult(int[] marks, out int total, out double avg, out string result)
        {
            total=0;
            bool isPass=true;
            foreach(int mark in marks)
            {
                if (mark < 35)
                {
                    isPass=false;
                }
                total+=mark;
            }
            avg=(double)total/marks.Length;
            result=isPass?"Pass":"Fail";
        }
        public static void Main()
        {
            System.Console.WriteLine("Enter how many subject marks you want to enter");
            if(!int.TryParse(Console.ReadLine(),out int n))
            {
                System.Console.WriteLine("Please enter only Numbers as Input");
                return;
            }
            int[] marks=new int[n];
            int mark=0;
            System.Console.WriteLine("Please Enter marks for each subject");
            for(int i=0;i<n;i++)
            {
                System.Console.Write($"Enter Marks for subject {i+1}: ");
                if(!int.TryParse(Console.ReadLine(),out mark))
                {
                    System.Console.WriteLine("Please enter only Numbers as input");
                    return;
                }
                marks[i]=mark;
            }
            Program.CalculateResult(marks, out int total, out double avg, out string result);
            
            Console.WriteLine($"Total: {total}");
            Console.WriteLine($"Average: {avg}");
            Console.WriteLine($"Result: {result}");
        }
    }
}