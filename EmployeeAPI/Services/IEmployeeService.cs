using EmployeeAPI.Models;
using System.Collections.Generic;

namespace EmployeeAPI.Services
{
    public interface IEmployeeService
    {
        public IEnumerable<Employee> GetEmployeeList();
        public Employee GetEmployeeById(int id);
        public Employee AddEmployee(Employee employee);
        public Employee UpdateEmployee(Employee employee);
        public bool DeleteEmployee(int Id);
    }
}
