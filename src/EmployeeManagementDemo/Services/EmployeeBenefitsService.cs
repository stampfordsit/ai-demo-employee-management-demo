using System;
using EmployeeManagementDemo.Models;

namespace EmployeeManagementDemo.Services;

public class EmployeeBenefitsService
{
    public bool EnrollInHealthInsurance(int employeeId, string planType)
    {
        // Mock implementation
        return true;
    }

    public int GetRemainingLeaveDays(int employeeId)
    {
        // Mock implementation
        return 15;
    }
    
    public bool RequestLeave(int employeeId, DateTime startDate, DateTime endDate)
    {
        // คำนวณจำนวนวันที่ต้องการลา (Calculation)
        int requestedDays = (int)(endDate - startDate).TotalDays;
        
        if (requestedDays <= 0)
        {
            return false; // วันที่ระบุไม่ถูกต้อง
        }

        int remainingDays = 15; // สมมติว่ามีวันลาคงเหลือ 15 วัน

        if (requestedDays > remainingDays)
        {
            return false; // วันลาไม่เพียงพอ
        }

        // หักวันลาและอนุมัติการลา (จำลอง)
        return true;
    }
}
