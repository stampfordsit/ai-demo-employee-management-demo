using Xunit;
using EmployeeManagementDemo.Models;

namespace BenchmarkTestProject.Tests
{
    public class TestClassName
    {
        [Fact]
        public void Employee_DefaultConstructor_IdIsZero()
        {
            var employee = new Employee();
            Assert.Equal(0, employee.Id);
        }

        [Fact]
        public void Employee_DefaultConstructor_NameIsEmptyString()
        {
            var employee = new Employee();
            Assert.Equal(string.Empty, employee.Name);
        }

        [Fact]
        public void Employee_DefaultConstructor_PositionIsEmptyString()
        {
            var employee = new Employee();
            Assert.Equal(string.Empty, employee.Position);
        }

        [Fact]
        public void Employee_DefaultConstructor_SalaryIsZero()
        {
            var employee = new Employee();
            Assert.Equal(0, employee.Salary);
        }

        [Fact]
        public void Employee_SetId_GetId_ReturnsSameValue()
        {
            var employee = new Employee();
            var id = 1;
            employee.Id = id;
            Assert.Equal(id, employee.Id);
        }

        [Fact]
        public void Employee_SetName_GetName_ReturnsSameValue()
        {
            var employee = new Employee();
            var name = "John Doe";
            employee.Name = name;
            Assert.Equal(name, employee.Name);
        }

        [Fact]
        public void Employee_SetPosition_GetPosition_ReturnsSameValue()
        {
            var employee = new Employee();
            var position = "Software Developer";
            employee.Position = position;
            Assert.Equal(position, employee.Position);
        }

        [Fact]
        public void Employee_SetSalary_GetSalary_ReturnsSameValue()
        {
            var employee = new Employee();
            var salary = 50000.00m;
            employee.Salary = salary;
            Assert.Equal(salary, employee.Salary);
        }

        [Fact]
        public void Employee_SetIdToNegative_GetId_ReturnsSameValue()
        {
            var employee = new Employee();
            var id = -1;
            employee.Id = id;
            Assert.Equal(id, employee.Id);
        }

        [Fact]
        public void Employee_SetNameToNull_GetName_ReturnsNull()
        {
            var employee = new Employee();
            employee.Name = null;
            Assert.Null(employee.Name);
        }

        [Fact]
        public void Employee_SetPositionToNull_GetPosition_ReturnsNull()
        {
            var employee = new Employee();
            employee.Position = null;
            Assert.Null(employee.Position);
        }

        [Fact]
        public void Employee_SetSalaryToNegative_GetSalary_ReturnsSameValue()
        {
            var employee = new Employee();
            var salary = -50000.00m;
            employee.Salary = salary;
            Assert.Equal(salary, employee.Salary);
        }
    }
}