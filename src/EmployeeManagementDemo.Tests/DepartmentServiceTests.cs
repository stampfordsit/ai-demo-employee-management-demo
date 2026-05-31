using BenchmarkSourceProject;
using Xunit;
using EmployeeManagementDemo.Services;

namespace BenchmarkTestProject.Tests
{
    public class TestClassName
    {
        private readonly DepartmentService _departmentService;

        public TestClassName()
        {
            _departmentService = new DepartmentService();
        }

        [Fact]
        public void GetAllDepartments_ReturnsDefaultDepartments()
        {
            var expectedDepartments = new List<string> { "HR", "Engineering", "Sales", "Marketing" };
            var departments = _departmentService.GetAllDepartments();
            Assert.Equal(expectedDepartments, departments);
        }

        [Fact]
        public void AddDepartment_WithValidDepartmentName_ReturnsTrue()
        {
            var departmentName = "IT";
            var result = _departmentService.AddDepartment(departmentName);
            Assert.True(result);
            Assert.Contains(departmentName, _departmentService.GetAllDepartments());
        }

        [Fact]
        public void AddDepartment_WithEmptyDepartmentName_ReturnsFalse()
        {
            var departmentName = string.Empty;
            var result = _departmentService.AddDepartment(departmentName);
            Assert.False(result);
            Assert.DoesNotContain(departmentName, _departmentService.GetAllDepartments());
        }

        [Fact]
        public void AddDepartment_WithExistingDepartmentName_ReturnsFalse()
        {
            var departmentName = "HR";
            var result = _departmentService.AddDepartment(departmentName);
            Assert.False(result);
            Assert.Contains(departmentName, _departmentService.GetAllDepartments());
        }

        [Fact]
        public void AddDepartment_WithNullDepartmentName_ReturnsFalse()
        {
            string? departmentName = null;
            var result = _departmentService.AddDepartment(departmentName);
            Assert.False(result);
            Assert.DoesNotContain(departmentName, _departmentService.GetAllDepartments());
        }

        [Fact]
        public void AddDepartment_WithWhitespaceDepartmentName_ReturnsFalse()
        {
            var departmentName = "   ";
            var result = _departmentService.AddDepartment(departmentName);
            Assert.False(result);
            Assert.DoesNotContain(departmentName, _departmentService.GetAllDepartments());
        }

        [Fact]
        public void AddDepartment_WithCaseSensitiveDepartmentName_ReturnsFalse()
        {
            var departmentName = "hr";
            var result = _departmentService.AddDepartment(departmentName);
            Assert.False(result);
            Assert.Contains("HR", _departmentService.GetAllDepartments());
        }
    }
}