using BenchmarkSourceProject;
using Xunit;
using EmployeeManagementDemo.Models;
using EmployeeManagementDemo.Services;

namespace BenchmarkTestProject.Tests
{
    public class TestClassName
    {
        private readonly SourceService _sourceService;

        public TestClassName()
        {
            _sourceService = new SourceService();
        }

        [Fact]
        public void CreateEmployee_ValidEmployee_EmployeeCreated()
        {
            // Arrange
            var employee = new Employee { Id = 1, Name = "Alice", Salary = 50000 };

            // Act
            _sourceService.CreateEmployee(employee);

            // Assert
            Assert.True(_sourceService.GetAnnualBonus(1) > 0);
        }

        [Fact]
        public void GetAnnualBonus_ValidEmployeeId_BonusReturned()
        {
            // Arrange
            var employee = new Employee { Id = 1, Name = "Alice", Salary = 50000 };
            _sourceService.CreateEmployee(employee);

            // Act
            var bonus = _sourceService.GetAnnualBonus(1);

            // Assert
            Assert.Equal(5000, bonus);
        }

        [Fact]
        public void GetAnnualBonus_InvalidEmployeeId_ZeroReturned()
        {
            // Act
            var bonus = _sourceService.GetAnnualBonus(1);

            // Assert
            Assert.Equal(0, bonus);
        }

        [Fact]
        public void CreateEmployee_DuplicateEmployeeId_ThrowsException()
        {
            // Arrange
            var employee = new Employee { Id = 1, Name = "Alice", Salary = 50000 };
            _sourceService.CreateEmployee(employee);

            // Act and Assert
            Assert.Throws<Exception>(() => _sourceService.CreateEmployee(employee));
        }

        [Fact]
        public void CreateEmployee_NegativeSalary_ThrowsException()
        {
            // Arrange
            var employee = new Employee { Id = 1, Name = "Alice", Salary = -50000 };

            // Act and Assert
            Assert.Throws<Exception>(() => _sourceService.CreateEmployee(employee));
        }

        [Fact]
        public void CreateEmployee_ZeroSalary_ThrowsException()
        {
            // Arrange
            var employee = new Employee { Id = 1, Name = "Alice", Salary = 0 };

            // Act and Assert
            Assert.Throws<Exception>(() => _sourceService.CreateEmployee(employee));
        }

        [Fact]
        public void GetAnnualBonus_MultipleEmployees_BonusReturned()
        {
            // Arrange
            var employee1 = new Employee { Id = 1, Name = "Alice", Salary = 50000 };
            var employee2 = new Employee { Id = 2, Name = "Bob", Salary = 60000 };
            _sourceService.CreateEmployee(employee1);
            _sourceService.CreateEmployee(employee2);

            // Act
            var bonus1 = _sourceService.GetAnnualBonus(1);
            var bonus2 = _sourceService.GetAnnualBonus(2);

            // Assert
            Assert.Equal(5000, bonus1);
            Assert.Equal(6000, bonus2);
        }
    }
}