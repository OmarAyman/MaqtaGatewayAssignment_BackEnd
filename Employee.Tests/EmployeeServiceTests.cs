using EmployeeAPI.Data;
using EmployeeAPI.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq;
using Xunit;

namespace Employee.Tests
{
    public class EmployeeServiceTests
    {
      
        [Fact]
        public void GetEmployeeList_ForEmployees_ReturnAllEmployees()
        {
            var data = new System.Collections.Generic.List<EmployeeAPI.Models.Employee>
            {
                new EmployeeAPI.Models.Employee { EmployeeName="Omar",Gender="Male",City="Cairo" },
                 new EmployeeAPI.Models.Employee { EmployeeName="Ahmed",Gender="Male",City="Cairo" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<EmployeeAPI.Models.Employee>>();
            mockSet.As<IQueryable<EmployeeAPI.Models.Employee>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<EmployeeAPI.Models.Employee>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<EmployeeAPI.Models.Employee>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<EmployeeAPI.Models.Employee>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DbContextClass>();
            mockContext.Setup(c => c.Employees).Returns(mockSet.Object);

            var service = new EmployeeService(mockContext.Object);

            var employees = service.GetEmployeeList();

           Assert.Equal(3, employees.ToList().Count);
            Assert.Equal("AAA", employees.ToList()[0].EmployeeName);
        }
       
    }
}
