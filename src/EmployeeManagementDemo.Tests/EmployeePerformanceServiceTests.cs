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
        public void EvaluatePerformance_ValidEmployeeId_ReturnsExcellent()
        {
            int employeeId = 1;
            string result = _employeePerformanceService.EvaluatePerformance(employeeId);
            Assert.Equal("Excellent", result);
        }

        [Fact]
        public void EvaluatePerformance_InvalidEmployeeId_ReturnsExcellent()
        {
            int employeeId = -1;
            string result = _employeePerformanceService.EvaluatePerformance(employeeId);
            Assert.Equal("Excellent", result);
        }

        [Fact]
        public void ScheduleReview_ValidEmployeeIdAndReviewDate_ReturnsTrue()
        {
            int employeeId = 1;
            DateTime reviewDate = DateTime.Now;
            bool result = _employeePerformanceService.ScheduleReview(employeeId, reviewDate);
            Assert.True(result);
        }

        [Fact]
        public void ScheduleReview_InvalidEmployeeIdAndReviewDate_ReturnsTrue()
        {
            int employeeId = -1;
            DateTime reviewDate = DateTime.Now;
            bool result = _employeePerformanceService.ScheduleReview(employeeId, reviewDate);
            Assert.True(result);
        }

        [Fact]
        public void ScheduleReview_ValidEmployeeIdAndPastReviewDate_ReturnsTrue()
        {
            int employeeId = 1;
            DateTime reviewDate = DateTime.Now.AddDays(-1);
            bool result = _employeePerformanceService.ScheduleReview(employeeId, reviewDate);
            Assert.True(result);
        }

        [Fact]
        public void CalculatePerformanceBonus_ValidEmployeeIdAndBaseSalary_ReturnsBonusAmount()
        {
            int employeeId = 1;
            decimal baseSalary = 10000m;
            decimal result = _employeePerformanceService.CalculatePerformanceBonus(employeeId, baseSalary);
            Assert.Equal(1500m, result);
        }

        [Fact]
        public void CalculatePerformanceBonus_InvalidEmployeeIdAndBaseSalary_ReturnsBonusAmount()
        {
            int employeeId = -1;
            decimal baseSalary = 10000m;
            decimal result = _employeePerformanceService.CalculatePerformanceBonus(employeeId, baseSalary);
            Assert.Equal(1500m, result);
        }

        [Fact]
        public void CalculatePerformanceBonus_ValidEmployeeIdAndZeroBaseSalary_ReturnsZeroBonusAmount()
        {
            int employeeId = 1;
            decimal baseSalary = 0m;
            decimal result = _employeePerformanceService.CalculatePerformanceBonus(employeeId, baseSalary);
            Assert.Equal(0m, result);
        }

        [Fact]
        public void CalculatePerformanceBonus_ValidEmployeeIdAndNegativeBaseSalary_ReturnsNegativeBonusAmount()
        {
            int employeeId = 1;
            decimal baseSalary = -10000m;
            decimal result = _employeePerformanceService.CalculatePerformanceBonus(employeeId, baseSalary);
            Assert.Equal(-1500m, result);
        }
    }
}