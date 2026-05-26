using EmployeeManagementDemo.Models;
using EmployeeManagementDemo.Services;

var service = new EmployeeService();

service.CreateEmployee(new Employee { Id = 1, Name = "Alice", Salary = 50000 });
service.CreateEmployee(new Employee { Id = 2, Name = "Bob", Salary = 60000 });

Console.WriteLine(service.GetAnnualBonus(1));
