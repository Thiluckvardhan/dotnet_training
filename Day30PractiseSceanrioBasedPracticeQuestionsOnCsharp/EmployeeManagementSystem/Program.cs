namespace EmployeeManagementSystem
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
        public DateTime JoiningDate { get; set; }
    }

    public class HRManager
    {
        public static List<Employee> employees = new();
        public void AddEmployee(string name, string dept, double salary)
        {
            Employee employee = new Employee
            {
                EmployeeId = employees.Count() + 1,
                Name = name,
                Department = dept,
                Salary = salary,
                JoiningDate = DateTime.Now
            };

            employees.Add(employee);
        }

        public SortedDictionary<string, List<Employee>> GroupEmployeesByDepartment()
        {
            SortedDictionary<string, List<Employee>> result = new SortedDictionary<string, List<Employee>>
            (
                employees.GroupBy(e => e.Department).ToDictionary(g => g.Key, g => g.ToList())
            );
            return result;
        }
        public double CalculateDepartmentSalary(string department)
        {
            double totalDepartmentSalary = employees.Where(d => d.Department == department).Sum(d => d.Salary);
            return totalDepartmentSalary;
        }
        public List<Employee> GetEmployeesJoinedAfter(DateTime date)
        {
            return employees
                .Where(e => e.JoiningDate > date)
                .ToList();
        }


    }
    class Program
    {
        static void Main()
        {
            HRManager hr = new HRManager();
            string choice;

            do
            {
                Console.WriteLine("\n--- Employee Management System ---");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Display Employees by Department");
                Console.WriteLine("3. Calculate Department Salary");
                Console.WriteLine("4. Find Employees Joined After Date");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice: ");

                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Department: ");
                        string dept = Console.ReadLine();

                        Console.Write("Salary: ");
                        double salary = double.Parse(Console.ReadLine());

                        hr.AddEmployee(name, dept, salary);
                        Console.WriteLine("Employee added successfully");
                        break;

                    case "2":
                        var grouped = hr.GroupEmployeesByDepartment();
                        foreach (var d in grouped)
                        {
                            Console.WriteLine($"{d.Key} :");
                            foreach (var emp in d.Value)
                            {
                                Console.WriteLine($"{emp.EmployeeId} {emp.Name} {emp.Salary}");
                            }
                        }
                        break;

                    case "3":
                        Console.Write("Enter department: ");
                        string department = Console.ReadLine();
                        Console.WriteLine("Total Salary: " + hr.CalculateDepartmentSalary(department));
                        break;

                    case "4":
                        Console.Write("Enter date (yyyy-mm-dd): ");
                        DateTime date = DateTime.Parse(Console.ReadLine());

                        var recent = hr.GetEmployeesJoinedAfter(date);
                        foreach (var emp in recent)
                        {
                            Console.WriteLine($"{emp.EmployeeId} {emp.Name} {emp.JoiningDate}");
                        }
                        break;

                    case "5":
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

            } while (choice != "5");
        }
    }

}
