using System.Collections.Generic;

namespace EmployeeApp.Core;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository repository;

    public EmployeeService(IEmployeeRepository repository)
    {
        this.repository = repository;
    }

    public Employee GetEmployeeOrThrow(int id)
    {
        if(id<=0) throw new ArgumentOutOfRangeException(nameof(id), "Id must be  positve");

        var employee = repository.GetById(id);
        if (employee is null)
            throw new KeyNotFoundException($"Employee with id{id} not found");
        return employee;
    }
}