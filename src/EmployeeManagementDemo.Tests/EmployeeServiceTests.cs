using EmployeeManagementDemo.Models;
using EmployeeManagementDemo.Services;
using Xunit;

namespace BenchmarkTestProject.Tests
{
    public class EmployeeServiceTests
    {
        private readonly EmployeeService _employeeService;

        public EmployeeServiceTests()
        {
            _employeeService = new EmployeeService();
        }

        [Fact]
        public void CreateEmployee_AddsEmployeeToTheList()
        {
            // Arrange
            var employee = new Employee { Id = 1, Salary = 1000 };

            // Act
            _employeeService.CreateEmployee(employee);

            // Assert
            var createdEmployee = _employeeService.GetEmployeeById(1);
            Assert.NotNull(createdEmployee);
            Assert.Equal(1, createdEmployee.Id);
        }

        [Fact]
        public void GetEmployeeById_ReturnsEmployee()
        {
            // Arrange
            var employee = new Employee { Id = 1, Salary = 1000 };
            _employeeService.CreateEmployee(employee);

            // Act
            var createdEmployee = _employeeService.GetEmployeeById(1);

            // Assert
            Assert.NotNull(createdEmployee);
            Assert.Equal(1, createdEmployee.Id);
        }

        [Fact]
        public void UpdateSalary_UpdatesSalary()
        {
            // Arrange
            var employee = new Employee { Id = 1, Salary = 1000 };
            _employeeService.CreateEmployee(employee);

            // Act
            _employeeService.UpdateSalary(1, 2000);

            // Assert
            var updatedEmployee = _employeeService.GetEmployeeById(1);
            Assert.NotNull(updatedEmployee);
            Assert.Equal(2000, updatedEmployee.Salary);
        }

        [Fact]
        public void UpdateSalary_ReturnsFalseIfEmployeeNotFound()
        {
            // Act
            var result = _employeeService.UpdateSalary(1, 2000);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void DeleteEmployee_RemovesEmployee()
        {
            // Arrange
            var employee = new Employee { Id = 1, Salary = 1000 };
            _employeeService.CreateEmployee(employee);

            // Act
            _employeeService.DeleteEmployee(1);

            // Assert
            var deletedEmployee = _employeeService.GetEmployeeById(1);
            Assert.Null(deletedEmployee);
        }

        [Fact]
        public void DeleteEmployee_ReturnsFalseIfEmployeeNotFound()
        {
            // Act
            var result = _employeeService.DeleteEmployee(1);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetAnnualBonus_ReturnsAnnualBonus()
        {
            // Arrange
            var employee = new Employee { Id = 1, Salary = 1000 };
            _employeeService.CreateEmployee(employee);

            // Act
            var annualBonus = _employeeService.GetAnnualBonus(1);

            // Assert
            Assert.Equal(100, annualBonus);
        }

        [Fact]
        public void GetAnnualBonus_ThrowsExceptionIfEmployeeNotFound()
        {
            // Act and Assert
            Assert.Throws<Exception>(() => _employeeService.GetAnnualBonus(1));
        }

        [Fact]
        public void PromoteEmployee_PromotesEmployee()
        {
            // Arrange
            var employee = new Employee { Id = 1, Salary = 1000, Position = "Developer" };
            _employeeService.CreateEmployee(employee);

            // Act
            _employeeService.PromoteEmployee(1, "Senior Developer", 2000);

            // Assert
            var promotedEmployee = _employeeService.GetEmployeeById(1);
            Assert.NotNull(promotedEmployee);
            Assert.Equal("Senior Developer", promotedEmployee.Position);
            Assert.Equal(2000, promotedEmployee.Salary);
        }

        [Fact]
        public void PromoteEmployee_ReturnsFalseIfEmployeeNotFound()
        {
            // Act
            var result = _employeeService.PromoteEmployee(1, "Senior Developer", 2000);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void PromoteEmployee_ThrowsArgumentExceptionIfNewSalaryIsNotGreater()
        {
            // Arrange
            var employee = new Employee { Id = 1, Salary = 1000, Position = "Developer" };
            _employeeService.CreateEmployee(employee);

            // Act and Assert
            Assert.Throws<ArgumentException>(() => _employeeService.PromoteEmployee(1, "Senior Developer", 1000));
        }

        [Fact]
        public void GetTotalPayroll_ReturnsTotalPayroll()
        {
            // Arrange
            var employee1 = new Employee { Id = 1, Salary = 1000 };
            var employee2 = new Employee { Id = 2, Salary = 2000 };
            _employeeService.CreateEmployee(employee1);
            _employeeService.CreateEmployee(employee2);

            // Act
            var totalPayroll = _employeeService.GetTotalPayroll();

            // Assert
            Assert.Equal(3000, totalPayroll);
        }

        [Fact]
        public void GetTotalPayrollById_ReturnsTotalPayrollById()
        {
            // Arrange
            var employee = new Employee { Id = 1, Salary = 1000 };
            _employeeService.CreateEmployee(employee);

            // Act
            var totalPayroll = _employeeService.GetTotalPayrollById(1);

            // Assert
            Assert.Equal(1000, totalPayroll);
        }

        [Fact]
        public void GetTotalPayrollById_ThrowsExceptionIfEmployeeNotFound()
        {
            // Act and Assert
            Assert.Throws<Exception>(() => _employeeService.GetTotalPayrollById(1));
        }

        [Fact]
        public void CreateEmployee_WithNegativeSalary_ThrowsNoException()
        {
            // Arrange
            var employee = new Employee { Id = 1, Salary = -1000 };

            // Act and Assert
            _employeeService.CreateEmployee(employee);
            var createdEmployee = _employeeService.GetEmployeeById(1);
            Assert.NotNull(createdEmployee);
            Assert.Equal(-1000, createdEmployee.Salary);
        }

        [Fact]
        public void UpdateSalary_WithNegativeSalary_UpdatesSalary()
        {
            // Arrange
            var employee = new Employee { Id = 1, Salary = 1000 };
            _employeeService.CreateEmployee(employee);

            // Act
            _employeeService.UpdateSalary(1, -2000);

            // Assert
            var updatedEmployee = _employeeService.GetEmployeeById(1);
            Assert.NotNull(updatedEmployee);
            Assert.Equal(-2000, updatedEmployee.Salary);
        }

        [Fact]
        public void PromoteEmployee_WithNegativeSalary_ThrowsArgumentException()
        {
            // Arrange
            var employee = new Employee { Id = 1, Salary = 1000, Position = "Developer" };
            _employeeService.CreateEmployee(employee);

            // Act and Assert
            Assert.Throws<ArgumentException>(() => _employeeService.PromoteEmployee(1, "Senior Developer", -2000));
        }

        [Fact]
        public void GetAnnualBonus_ForEmployeeWithNegativeSalary_ReturnsNegativeAnnualBonus()
        {
            // Arrange
            var employee = new Employee { Id = 1, Salary = -1000 };
            _employeeService.CreateEmployee(employee);

            // Act
            var annualBonus = _employeeService.GetAnnualBonus(1);

            // Assert
            Assert.Equal(-100, annualBonus);
        }
    }
}

