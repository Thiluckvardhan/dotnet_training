
namespace BasicsOfBasics
{
    internal class Program
    {

        public class A
        {
            public  string Stataus  { get; set; }
        }
        static void Main(string[] args)
        {


            GenericsExamples genericsExamples = new GenericsExamples();


            genericsExamples.Sample1();


            SomeClass someClass = new SomeClass();

            if (false)// Uncomment to execute the below block
            {
                string result = someClass.SomeMethod(5);
                Console.WriteLine(result);
                int input1 = 67;
                int input2 = 7;
                int sum = someClass.SomeMethod(ref input1, ref input2);
                Console.WriteLine($"Method with two int parameters called. Sum: {sum}");
                Console.WriteLine($"input1 {input1}");
                Console.WriteLine($"input2 {input2}");
           

            int x=int.MaxValue-99; 
            int y=1;
            int ans = someClass.Add(x, y);
            Console.WriteLine($"Ans= {ans}");

            int n = 10;
            int square, half, addBy3;
            int original = someClass.MultiMath(n, out square, out half, out addBy3);
            Console.WriteLine($"Original: {original}, Square: {square}, Half: {half}, AddBy3: {addBy3}");
            }

            A a = new A();

            A object1 = a;
            A object2 = object1;

            a.Stataus = "Active";

            Console.WriteLine(a.Stataus);
            Console.WriteLine(((A)object1).Stataus);
            Console.WriteLine(((A)object2).Stataus);


            Console.WriteLine("************************************************************");
            Console.WriteLine( a.Stataus);
            Console.WriteLine(object2.Stataus);

            Console.WriteLine("************************************************************");

            DoSomethinWithA(a);

            Console.WriteLine(a.Stataus);

            dynamic d = 10;
            d= "Gopi";

            var v = 20;
          //v = "Raja"; // This will give compile time error



        }

        private static void DoSomethinWithA(A a)
        {
             a.Stataus = "I have called , By scope reach Caller InActive";
        }
    }   

    public class SomeClass
    {
        public string SomeMethod(int n)
        {
            return $"Method with int parameter called {n}";
        }

        public int SomeMethod(ref int a, ref int b)
        {
            int n = a + b;
            a = a * a;
            b = a + 500;
            return n;
        }

        public int MultiMath(int n, out int sqrValue, out int halfValue, out int addBy3)
        {
            sqrValue=0;
            sqrValue = n * n;
            halfValue = n / 2;
            addBy3 = n + 3;
            return n;
        }

        public int Add(int a, int b)
        {
            checked
            {
                int c = a + b;
                return c;

            }

        }
    }
}
