// namespace ReflectionsPractise
// {
//     public class Employee
//     {
//         public int Id { get; set; }
//         public string Name { get; set; } = "";
//         public decimal Salary { get; private set; }

//         private string secretCode = "X9Z";

//         public Employee() { }

//         public Employee(int id, string name, decimal salary)
//         {
//             Id = id;
//             Name = name;
//             Salary = salary;
//         }

//         public void GiveRaise(decimal amount)
//         {
//             Salary += amount;
//         }

//         private string GetSecretCode() => secretCode;
//     }
//     public class Program
//     {
//         static void Main()
//         {
//             Employee emp = new Employee(101, "Arun", 45000);

//             Type t1 = typeof(Employee);     // compile-time
//             Type t2 = emp.GetType();        // runtime

//             Console.WriteLine(t1.FullName);
//             Console.WriteLine(t2.FullName);
//             Console.WriteLine(t1 == t2);    // True
//         }
//     }
// }
using System.Reflection;
namespace ReflectionsPractise
{
    public class Program
    {
        public static void Main()
        {
            Type t = typeof(Adder);               // 1. Get type
            object obj = Activator.CreateInstance(t); // 2. Create instance

            MethodInfo method = t.GetMethod("Add");   // 3. Get method
            method.Invoke(obj, new object[] { 10, 20 }); // Call method
        }
    }

}