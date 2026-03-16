namespace EmployeeApp.Core;

public interface IEmployeeService
{
    Employee GetEmployeeOrThrow(int id);
}
