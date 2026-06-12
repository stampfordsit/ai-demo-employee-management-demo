using System;
using EmployeeManagementDemo.Models;

namespace EmployeeManagementDemo.Services;

public class EmployeePerformanceService
{
    public string EvaluatePerformance(int employeeId)
    {
        // Mock implementation
        return "Excellent";
    }

    public bool ScheduleReview(int employeeId, DateTime reviewDate)
    {
        // Mock implementation
        return true;
    }
    
    public decimal CalculatePerformanceBonus(int employeeId, decimal baseSalary)
    {
        // Mock implementation
        return baseSalary * 0.15m;
    }
}
