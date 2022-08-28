using EmployeeAPI.Data;
using EmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DbContextClass _dbContext;

        public EmployeeService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public Employee AddEmployee(Employee employee)
        {
            var result = _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public bool DeleteEmployee(int Id)
        {
            var filteredData = _dbContext.Employees.Where(x => x.EmployeeId == Id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }

        public Employee GetEmployeeById(int id)
        {
            return _dbContext.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
        }

        public IEnumerable<Employee> GetEmployeeList()
        {
            return _dbContext.Employees.ToList();
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var result = _dbContext.Employees.Update(employee);
            _dbContext.SaveChanges();
            return result.Entity;
        }
    }
}
