using ApiDemoCRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemoCRUD.EmployeeData
{
    public class MockEmployeeData : IEmployeeData
    {
        private List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
               Id = Guid.NewGuid(),
               Name = "Employee One"
            },
             new Employee()
            {
               Id = Guid.NewGuid(),
               Name = "Employee Two"
            },
              new Employee()
            {
               Id = Guid.NewGuid(),
               Name = "Employee Three"
            }
        };

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            employees.Add(employee);

            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public Employee EditEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployee(Guid id)
        {
            return employees.SingleOrDefault(x => x.Id == id);
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }
    }
}
