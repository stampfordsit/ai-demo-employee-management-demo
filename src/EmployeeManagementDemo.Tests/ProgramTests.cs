using Xunit;
using EmployeeManagementDemo.Models;
using EmployeeManagementDemo.Services;

namespace BenchmarkTestProject.Tests
{
    public class ProgramTests
    {
        private readonly EmployeeService _EmployeeService;

        public ProgramTests()
        {
            _EmployeeService = new EmployeeService();
        }

        [Fact]
        public void CreateEmployee_ValidEmployee_EmployeeCreated()
        {
            // Arrange
            var employee = new Employee { Id = 1, Name = "Alice", Salary = 50000 };

            // Act
            _EmployeeService.CreateEmployee(employee);

            // Assert
            Assert.True(_EmployeeService.GetAnnualBonus(1) > 0);
        }

        [Fact]
        public void GetAnnualBonus_ValidEmployeeId_BonusReturned()
        {
            // Arrange
            var employee = new Employee { Id = 1, Name = "Alice", Salary = 50000 };
            _EmployeeService.CreateEmployee(employee);

            // Act
            var bonus = _EmployeeService.GetAnnualBonus(1);

            // Assert
            Assert.Equal(5000, bonus);
        }

        [Fact]
        public void GetAnnualBonus_InvalidEmployeeId_ZeroReturned()
        {
            // Act
            var bonus = _EmployeeService.GetAnnualBonus(1);

            // Assert
            Assert.Equal(0, bonus);
        }

        [Fact]
        public void CreateEmployee_DuplicateEmployeeId_ThrowsException()
        {
            // Arrange
            var employee = new Employee { Id = 1, Name = "Alice", Salary = 50000 };
            _EmployeeService.CreateEmployee(employee);

            // Act and Assert
            Assert.Throws<Exception>(() => _EmployeeService.CreateEmployee(employee));
        }

        [Fact]
        public void CreateEmployee_NegativeSalary_ThrowsException()
        {
            // Arrange
            var employee = new Employee { Id = 1, Name = "Alice", Salary = -50000 };

            // Act and Assert
            Assert.Throws<Exception>(() => _EmployeeService.CreateEmployee(employee));
        }

        [Fact]
        public void CreateEmployee_ZeroSalary_ThrowsException()
        {
            // Arrange
            var employee = new Employee { Id = 1, Name = "Alice", Salary = 0 };

            // Act and Assert
            Assert.Throws<Exception>(() => _EmployeeService.CreateEmployee(employee));
        }

        [Fact]
        public void GetAnnualBonus_MultipleEmployees_BonusReturned()
        {
            // Arrange
            var employee1 = new Employee { Id = 1, Name = "Alice", Salary = 50000 };
            var employee2 = new Employee { Id = 2, Name = "Bob", Salary = 60000 };
            _EmployeeService.CreateEmployee(employee1);
            _EmployeeService.CreateEmployee(employee2);

            // Act
            var bonus1 = _EmployeeService.GetAnnualBonus(1);
            var bonus2 = _EmployeeService.GetAnnualBonus(2);

            // Assert
            Assert.Equal(5000, bonus1);
            Assert.Equal(6000, bonus2);
        }
    }
}

