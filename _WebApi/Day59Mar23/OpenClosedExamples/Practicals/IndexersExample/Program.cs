namespace IndexersExample
{
    using System;

    class MyData
    {
        private string[] values = new string[3];

        // Indexer declaration
        public string this[int index]
        {
            get
            {
                return values[index];
            }
            set
            {
                values[index] = value;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            MyData obj = new MyData();

            obj[0] = "C";
            obj[1] = "C++";
            obj[2] = "C#";

            Console.WriteLine("First Value: " + obj[0]);
            Console.WriteLine("Second Value: " + obj[1]);
            Console.WriteLine("Third Value: " + obj[2]);
        }
    }
}
