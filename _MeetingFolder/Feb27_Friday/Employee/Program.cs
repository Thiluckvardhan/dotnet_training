public class Employee
{
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Title { get; set; }
    public DateTime DOB { get; set; }
    public DateTime DOJ { get; set; }
    public string City { get; set; }
}

public class Program
{
    public static List<Employee> empList = new List<Employee>
{
new Employee() {EmployeeID = 1001,FirstName = "Malcolm",LastName = "Daruwalla",Title = "Manager",DOB = DateTime.Parse("1984-01-02"),DOJ = DateTime.Parse("2011-08-09"),City = "Mumbai"},
new Employee() {EmployeeID = 1002,FirstName = "Asdin",LastName = "Dhalla",Title = "AsstManager",DOB = DateTime.Parse("1984-08-20"),DOJ = DateTime.Parse("2012-7-7"),City = "Mumbai"},
new Employee() {EmployeeID = 1003,FirstName = "Madhavi",LastName = "Oza",Title = "Consultant",DOB = DateTime.Parse("1987-11-14"),DOJ = DateTime.Parse("2105-12-04"),City = "Pune"},
new Employee() {EmployeeID = 1004,FirstName = "Saba",LastName = "Shaikh",Title = "SE",DOB = DateTime.Parse("6/3/1990"),DOJ = DateTime.Parse("2/2/2016"),City = "Pune"},
new Employee() {EmployeeID = 1005,FirstName = "Nazia",LastName = "Shaikh",Title = "SE",DOB = DateTime.Parse("3/8/1991"),DOJ = DateTime.Parse("2/2/2016"),City = "Mumbai"},
new Employee() {EmployeeID = 1006,FirstName = "Suresh",LastName = "Pathak",Title = "Consultant",DOB = DateTime.Parse("11/7/1989"),DOJ = DateTime.Parse("8/8/2014"),City = "Chennai"},
new Employee() {EmployeeID = 1007,FirstName = "Vijay",LastName = "Natrajan",Title = "Consultant",DOB = DateTime.Parse("12/2/1989"),DOJ = DateTime.Parse("6/1/2015"),City = "Mumbai"},
new Employee() {EmployeeID = 1008,FirstName = "Rahul",LastName = "Dubey",Title = "Associate",DOB = DateTime.Parse("11/11/1993"),DOJ = DateTime.Parse("11/6/2014"),City = "Chennai"},
new Employee() {EmployeeID = 1009,FirstName = "Amit",LastName = "Mistry",Title = "Associate",DOB = DateTime.Parse("8/12/1992"),DOJ = DateTime.Parse("12/3/2014"),City = "Chennai"},
new Employee() {EmployeeID = 1010,FirstName = "Sumit",LastName = "Shah",Title = "Manager",DOB = DateTime.Parse("4/12/1991"),DOJ = DateTime.Parse("1/2/2016"),City = "Pune"},


};
    public static void Print(IEnumerable<Employee> employees)
    {
        foreach (var employee in employees)
        {
            Console.WriteLine($"Employee Id: {employee.EmployeeID}, FirstName: {employee.FirstName}, LastName: {employee.LastName}, Title: {employee.Title}, DOB: {employee.DOB}, DOJ: {employee.DOJ}, City: {employee.City}");
        }
    }

    public static void Main()
    {
        Console.WriteLine("All Employees");
        Print(empList);

        Console.WriteLine("********************************************************************************************************************************************");
        Console.WriteLine("Employees not from mumbai");
        var notMumbai = empList.Where(emp => emp.City != "Mumbai");
        Print(notMumbai);

        Console.WriteLine("********************************************************************************************************************************************");
        Console.WriteLine("Employees with AsstManager Title");
        var asstManager = empList.Where(emp => emp.Title == "AsstManager");
        Print(asstManager);

        Console.WriteLine("********************************************************************************************************************************************");
        Console.WriteLine("Employees Whoose Last Name starts with S");
        var lastNameWithS = empList.Where(emp => emp.LastName.StartsWith("S"));
        Print(lastNameWithS);

        Console.WriteLine("********************************************************************************************************************************************");
        Console.WriteLine("Employees Joined Before 2015-1-1");
        var joinedBefore2015 = empList.Where(e => e.DOJ < new DateTime(2015, 1, 1));
        Print(joinedBefore2015);

        Console.WriteLine("********************************************************************************************************************************************");
        Console.WriteLine("Employees DoB after 1990-1-1");
        var DoBAfter1990 = empList.Where(e => e.DOB > new DateTime(1990, 1, 1));
        Print(DoBAfter1990);

        Console.WriteLine("********************************************************************************************************************************************");
        Console.WriteLine("Employees whose Designation is Associate");
        var Designation = empList.Where(emp => emp.Title == "Consultant" || emp.Title == "Associate");
        Print(Designation);

        Console.WriteLine("********************************************************************************************************************************************");
        Console.WriteLine($"Employees Count : {empList.Count()}");

        Console.WriteLine("********************************************************************************************************************************************");
        Console.WriteLine("Employees who belong to Chennai");
        var chennaiemps = empList.Where(emp => emp.City == "Chennai");
        Print(chennaiemps);

        Console.WriteLine("********************************************************************************************************************************************");
        Console.WriteLine($"Highest employee Id : {empList.Max(emp => emp.EmployeeID)}");

        Console.WriteLine("********************************************************************************************************************************************");
        Console.WriteLine("Employees Joined After 2015");
        var empafter2015 = empList.Where(emp => emp.DOJ > new DateTime(2015, 1, 1));
        Print(empafter2015);

        Console.WriteLine("********************************************************************************************************************************************");
        Console.WriteLine("Employees whoose designation is not Associate");
        var notAssociate = empList.Where(emp => emp.Title != "Associate");
        Print(notAssociate);

        Console.WriteLine("********************************************************************************************************************************************");
        Console.WriteLine($"Employees Based on city");

        var basedOnCity = empList.GroupBy(emp => emp.City).ToDictionary(g => g.Key, g => g.Count());
        foreach (var employee in basedOnCity)
        {
            Console.WriteLine($"{employee.Key} -- {employee.Value}");
        }

        Console.WriteLine("********************************************************************************************************************************************");
        Console.WriteLine($"Employees Based on city and Title");

        var employeesByCityAndTitle = empList.GroupBy(e => new { e.City, e.Title })
                                             .ToDictionary(g => (g.Key.City, g.Key.Title), g => g.Count());
        foreach (var item in employeesByCityAndTitle)
        {
            Console.WriteLine($"{item.Key.City} - {item.Key.Title} - {item.Value}");
        }
    }
}