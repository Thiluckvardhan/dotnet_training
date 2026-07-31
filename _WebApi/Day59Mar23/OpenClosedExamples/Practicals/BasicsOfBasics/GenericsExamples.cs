using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicsOfBasics
{
    public class GenericsExamples
    {

        public void Sample1()
        {
            List<string> names = new List<string>();
            names.Add("Arul");
            names.Add("Chitra");
            names.Add("Bala");

            names.Sort();

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }



            //List<int> myList = new List<int>();
            //myList.Add(10);
            //myList.Add(20);
            //myList.Add(30);
            //foreach (var item in myList)
            //{
            //    Console.WriteLine(item);
            //}
            //Stack<string> myStack = new Stack<string>();
            //myStack.Push("First");
            //myStack.Push("Second");
            //myStack.Push("Third");
            //if (myStack.Count > 0)
            //{
            //    string val = myStack.Pop();
            //    Console.WriteLine(val);
            //}
            //Queue<double> queue = new Queue<double>();
            //queue.Enqueue(1.1);
            //queue.Enqueue(2.2);
            //queue.Enqueue(3.3);
            //double dequeuedValue = queue.Dequeue();
            //Console.WriteLine(dequeuedValue);
        }
    }
}
