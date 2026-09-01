using System;

class Employee
{
    public string Name { get; set; }
    public double HoursWorked { get; set; }
    public double HourlyRate { get; set; }
}

class PayrollCalculator
{
    public double CalculateSalary(Employee emp)
    {
        double regularPay;
        double overtimePay = 0;

        if (emp.HoursWorked <= 40)
        {
            regularPay = emp.HoursWorked * emp.HourlyRate;
        }
        else
        {
            regularPay = 40 * emp.HourlyRate;
            overtimePay = (emp.HoursWorked - 40) * emp.HourlyRate * 1.5;
        }

        return Math.Round(regularPay + overtimePay, 2);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Employee emp = new Employee();
        PayrollCalculator payroll = new PayrollCalculator();

        Console.Write("Enter Employee Name: ");
        emp.Name = Console.ReadLine();

        double hours,rate;
        Console.Write("Enter Hours Worked: ");
        while (!double.TryParse(Console.ReadLine(), out  hours) || hours < 0)
        {
            Console.WriteLine("Invalid Hours!");
            Console.Write("Enter Hours Worked: ");
        }
        emp.HoursWorked = hours;

        Console.Write("Enter Hourly Rate: ");
        while (!double.TryParse(Console.ReadLine(), out rate) || rate < 0)
        {
            Console.WriteLine("Invalid Hourly Rate!");
            Console.Write("Enter Hourly Rate: ");
        }
        emp.HourlyRate = rate;

        double salary = payroll.CalculateSalary(emp);

        Console.WriteLine("\n------ PAYROLL ------");
        Console.WriteLine($"Employee Name : {emp.Name}");
        Console.WriteLine($"Hours Worked  : {emp.HoursWorked}");
        Console.WriteLine($"Hourly Rate   : {emp.HourlyRate:F2}");
        Console.WriteLine($"Gross Salary  : {salary:F2}");
    }
}