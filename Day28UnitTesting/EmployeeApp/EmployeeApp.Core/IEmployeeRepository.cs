using EmployeeApp.Core;
using System.Collections;
using System.Collections.Generic;

public interface IEmployeeRepository
{
    Employee? GetById(int id);
    IReadOnlyCollection<Employee> GetAll();
    void Add(Employee employee);
    void Update(Employee employee);
    void Delete(int id);
}