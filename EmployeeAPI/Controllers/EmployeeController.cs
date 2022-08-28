using EmployeeAPI.Models;
using EmployeeAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService _employeeService)
        {
            employeeService = _employeeService;
        }
        [HttpGet]
        public IEnumerable<Employee> EmployeeList()
        {
            var employeeList = employeeService.GetEmployeeList();
            return employeeList;
        }
        [HttpGet("{id}")]
        public Employee GetemployeeById(int id)
        {
            return employeeService.GetEmployeeById(id);
        }
        [HttpPost]
        public Employee Addemployee(Employee employee)
        {
            return employeeService.AddEmployee(employee);
        }
        [HttpPut]
        public Employee Updateemployee(Employee employee)
        {
            return employeeService.UpdateEmployee(employee);
        }
        [HttpDelete("{id}")]
        public bool DeleteEmployee(int id)
        {
            return employeeService.DeleteEmployee(id);
        }
    }
}
