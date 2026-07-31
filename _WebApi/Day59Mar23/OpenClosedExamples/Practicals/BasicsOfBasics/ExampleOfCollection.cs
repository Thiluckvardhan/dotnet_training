using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicsOfBasics
{
    public class ExampleOfCollection
    {

        public void Sample1()
        {
            ArrayList myList = new ArrayList(16);
            myList.Add(10);
            myList.Add("Hello");
            myList.Add(20.5);
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }

            Stack myStack = new Stack();
            myStack.Push(100);
            myStack.Push("World");
            myStack.Push(30.5);

            if (myStack.Count > 0)
                if ( myStack.Pop() is int)
                {
                    int val = (int)myStack.Pop();
                    Console.WriteLine(val);
                }    

           Queue queue = new Queue();
            queue.Enqueue(1);
            queue.Enqueue("Queue");
            queue.Enqueue(3.5);
            queue.Dequeue();


        }

    }
}
