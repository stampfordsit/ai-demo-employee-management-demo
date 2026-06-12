using BenchmarkSourceProject;
using EmployeeManagementDemo.Services;
using Xunit;

namespace BenchmarkTestProject.Tests
{
    public class TestClassName
    {
        private readonly EmployeePerformanceService _employeePerformanceService;

        public TestClassName()
        {
            _employeePerformanceService = new EmployeePerformanceService();
        }

        [Fact]
        public void EvaluatePerformance_ReturnsString()
        {
            int employeeId = 1;
            string result = _employeePerformanceService.EvaluatePerformance(employeeId);
            Assert.IsType<string>(result);
            Assert.Equal("Excellent", result);
        }

        [Fact]
        public void EvaluatePerformance_InvalidEmployeeId_ReturnsString()
        {
            int employeeId = -1;
            string result = _employeePerformanceService.EvaluatePerformance(employeeId);
            Assert.IsType<string>(result);
            Assert.Equal("Excellent", result);
        }

        [Fact]
        public void ScheduleReview_ReturnsTrue()
        {
            int employeeId = 1;
            DateTime reviewDate = DateTime.Now;
            bool result = _employeePerformanceService.ScheduleReview(employeeId, reviewDate);
            Assert.True(result);
        }

        [Fact]
        public void ScheduleReview_InvalidEmployeeId_ReturnsTrue()
        {
            int employeeId = -1;
            DateTime reviewDate = DateTime.Now;
            bool result = _employeePerformanceService.ScheduleReview(employeeId, reviewDate);
            Assert.True(result);
        }

        [Fact]
        public void ScheduleReview_PastReviewDate_ReturnsTrue()
        {
            int employeeId = 1;
            DateTime reviewDate = DateTime.Now.AddDays(-1);
            bool result = _employeePerformanceService.ScheduleReview(employeeId, reviewDate);
            Assert.True(result);
        }

        [Fact]
        public void CalculatePerformanceBonus_ReturnsBonusAmount()
        {
            int employeeId = 1;
            decimal baseSalary = 10000m;
            decimal result = _employeePerformanceService.CalculatePerformanceBonus(employeeId, baseSalary);
            Assert.IsType<decimal>(result);
            Assert.Equal(1500m, result);
        }

        [Fact]
        public void CalculatePerformanceBonus_ZeroBaseSalary_ReturnsZero()
        {
            int employeeId = 1;
            decimal baseSalary = 0m;
            decimal result = _employeePerformanceService.CalculatePerformanceBonus(employeeId, baseSalary);
            Assert.IsType<decimal>(result);
            Assert.Equal(0m, result);
        }

        [Fact]
        public void CalculatePerformanceBonus_NegativeBaseSalary_ReturnsNegativeBonus()
        {
            int employeeId = 1;
            decimal baseSalary = -10000m;
            decimal result = _employeePerformanceService.CalculatePerformanceBonus(employeeId, baseSalary);
            Assert.IsType<decimal>(result);
            Assert.Equal(-1500m, result);
        }
    }
}