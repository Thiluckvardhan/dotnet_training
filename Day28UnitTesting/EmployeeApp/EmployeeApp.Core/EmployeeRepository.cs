using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApp.Core
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Employee emp;
        public void Add(Employee employee)
        {
            emp=employee;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public Employee? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
