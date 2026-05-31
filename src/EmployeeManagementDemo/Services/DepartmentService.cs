namespace EmployeeManagementDemo.Services;

public class DepartmentService
{
    private readonly List<string> _departments = new() { "HR", "Engineering", "Sales", "Marketing" };

    public List<string> GetAllDepartments()
    {
        return _departments;
    }

    public bool AddDepartment(string departmentName)
    {
        if (string.IsNullOrWhiteSpace(departmentName) || _departments.Contains(departmentName))
            return false;

        _departments.Add(departmentName);
        return true;
    }
}
