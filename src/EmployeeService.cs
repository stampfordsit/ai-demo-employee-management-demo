using System;

namespace DemoApp {
    public class Employee {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
    }

    public class EmployeeService {
        // Calculate the annual bonus based on a percentage
        public decimal CalculateAnnualBonus(Employee employee, decimal bonusPercentage) {
            if (employee == null) throw new ArgumentNullException(nameof(employee));
            if (bonusPercentage < 0 || bonusPercentage > 100) {
                throw new ArgumentException("Bonus percentage must be between 0 and 100.");
            }
            
            return employee.Salary * (bonusPercentage / 100m);
        }

        // Promote the employee to a new position with a new salary
        public void PromoteEmployee(Employee employee, string newPosition, decimal newSalary) {
            if (employee == null) throw new ArgumentNullException(nameof(employee));
            if (newSalary <= employee.Salary) {
                throw new ArgumentException("New salary must be greater than the current salary.");
            }

            employee.Position = newPosition;
            employee.Salary = newSalary;
        }
    }
}
