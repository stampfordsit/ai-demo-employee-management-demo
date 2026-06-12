using Xunit;
using EmployeeManagementDemo.Services;

namespace BenchmarkTestProject.Tests
{
    public class EmployeeBenefitsServiceTests
    {
        private readonly EmployeeBenefitsService _employeeBenefitsService;

        public EmployeeBenefitsServiceTests()
        {
            _employeeBenefitsService = new EmployeeBenefitsService();
        }

        [Fact]
        public void EnrollInHealthInsurance_ValidInput_ReturnsTrue()
        {
            int employeeId = 1;
            string planType = "Basic";
            bool result = _employeeBenefitsService.EnrollInHealthInsurance(employeeId, planType);
            Assert.True(result);
        }

        [Fact]
        public void GetRemainingLeaveDays_ValidInput_ReturnsRemainingDays()
        {
            int employeeId = 1;
            int result = _employeeBenefitsService.GetRemainingLeaveDays(employeeId);
            Assert.Equal(15, result);
        }

        [Fact]
        public void RequestLeave_ValidInput_ReturnsTrue()
        {
            int employeeId = 1;
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now.AddDays(10);
            bool result = _employeeBenefitsService.RequestLeave(employeeId, startDate, endDate);
            Assert.True(result);
        }

        [Fact]
        public void RequestLeave_InvalidInput_ReturnsFalse()
        {
            int employeeId = 1;
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now.AddDays(-10);
            bool result = _employeeBenefitsService.RequestLeave(employeeId, startDate, endDate);
            Assert.False(result);
        }

        [Fact]
        public void RequestLeave_InsufficientLeaveDays_ReturnsFalse()
        {
            int employeeId = 1;
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now.AddDays(20);
            bool result = _employeeBenefitsService.RequestLeave(employeeId, startDate, endDate);
            Assert.False(result);
        }

        [Fact]
        public void RequestLeave_BoundaryLeaveDays_ReturnsTrue()
        {
            int employeeId = 1;
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now.AddDays(15);
            bool result = _employeeBenefitsService.RequestLeave(employeeId, startDate, endDate);
            Assert.False(result);
        }

        [Theory]
        [InlineData(1, 10)]
        [InlineData(1, 5)]
        [InlineData(1, 15)]
        public void RequestLeave_ParameterizedTest_ReturnsExpectedResult(int employeeId, int days)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now.AddDays(days);
            bool result = _employeeBenefitsService.RequestLeave(employeeId, startDate, endDate);
            if (days <= 15)
            {
                Assert.True(result);
            }
            else
            {
                Assert.False(result);
            }
        }
    }
}

