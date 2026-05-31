using EmployeeManagementDemo.Models;

namespace EmployeeManagementDemo.Services;

public class EmployeeService
{
    private readonly List<Employee> _employees = new();

    public void CreateEmployee(Employee employee)
    {
        _employees.Add(employee);
    }

    public Employee? GetEmployeeById(int id)
    {
        return _employees.FirstOrDefault(e => e.Id == id);
    }

    public bool UpdateSalary(int id, decimal newSalary)
    {
        var employee = GetEmployeeById(id);

        if (employee == null)
            return false;

        employee.Salary = newSalary;

        return true;
    }

    public bool DeleteEmployee(int id)
    {
        var employee = GetEmployeeById(id);

        if (employee == null)
            return false;

        _employees.Remove(employee);

        return true;
    }

    public decimal GetAnnualBonus(int id)
    {
        var employee = GetEmployeeById(id);

        if (employee == null)
            throw new Exception("Employee not found");

        return employee.Salary * 0.10m;
    }

    public bool PromoteEmployee(int id, string newPosition, decimal newSalary)
    {
        var employee = GetEmployeeById(id);

        if (employee == null)
            return false;

        if (newSalary <= employee.Salary)
            throw new ArgumentException("New salary must be greater than the current salary.");

        employee.Position = newPosition;
        employee.Salary = newSalary;

        return true;
    }

    public decimal GetTotalPayroll()
    {
        return _employees.Sum(e => e.Salary);
    }
}