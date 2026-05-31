# EmployeeManagementDemo

A demo application built with **.NET 8.0** and **C#** that manages employee records in-memory, performing basic CRUD operations and calculating annual employee bonuses.

---

## 📂 Project Structure

```text
EmployeeManagementDemo/
│
├── .github/
│   └── workflows/
│       └── ai-unit-test.yml         # GitHub Actions workflow for AI Unit Test Generation
│
├── EmployeeManagementDemo.sln       # Visual Studio Solution file
│
└── src/
    └── EmployeeManagementDemo/      # Core Project directory
        ├── Models/
        │   └── Employee.cs          # Employee entity model
        ├── Services/
        │   └── EmployeeService.cs   # In-memory CRUD and calculation logic
        ├── Program.cs               # Console Application Entry Point (with top-level statements)
        └── EmployeeManagementDemo.csproj # MSBuild Project file
```

---

## 🛠 Features & Methods

### 1. `Employee` Model
Represents an individual employee's data structure:
- `Id` (`int`): Unique identifier of the employee.
- `Name` (`string`): The name of the employee.
- `Position` (`string`): The current position or title of the employee.
- `Salary` (`decimal`): The current salary of the employee.

### 2. `EmployeeService`
Handles the core business logic using an in-memory data store (`List<Employee>`):

| Method | Parameters | Return Type | Description |
| :--- | :--- | :--- | :--- |
| `CreateEmployee` | `Employee employee` | `void` | Adds a new employee record to the memory store. |
| `GetEmployeeById` | `int id` | `Employee?` | Retrieves an employee by their ID. Returns `null` if not found. |
| `UpdateSalary` | `int id`, `decimal newSalary` | `bool` | Updates the salary of the specified employee. Returns `false` if the employee is not found. |
| `DeleteEmployee` | `int id` | `bool` | Removes the employee record from the store. Returns `false` if not found. |
| `GetAnnualBonus` | `int id` | `decimal` | Calculates a **10% annual bonus** based on the employee's salary. Throws an `Exception` if the employee does not exist. |
| `PromoteEmployee` | `int id`, `string newPosition`, `decimal newSalary` | `bool` | Promotes the employee to a new position with a higher salary. Returns `false` if employee is not found. Throws an exception if the new salary is not greater. |
| `GetTotalPayroll` | (None) | `decimal` | Returns the total sum of all employees' salaries in the memory store. |

### 3. CI/CD & Automation (`.github/workflows`)
The project includes a GitHub Actions workflow (`ai-unit-test.yml`) designed to automatically trigger an **AI Unit Test Generation Webhook** whenever a Pull Request modifying `.cs` files is created. This ensures seamless automated testing for every code contribution.

**Workflow Details:**
- **Trigger:** Pull Requests containing changes to `*.cs` files.
- **Action:** Sends a POST request to an external webhook (Ngrok).
- **Payload Data:** Includes repository URL, PR number, branch name, the AI workflow mode (`ultimate_hybrid`), and the specified LLM model (`gptmini`).

**Pro Tips for CI/CD Pipeline:**
- **Ngrok Static Domain:** To avoid changing the URL in `.yml` every time Ngrok restarts, claim a free static domain in your Ngrok dashboard and run it using: `ngrok http --domain=your-static-domain.ngrok-free.dev 3005`.
- **Model Selection:** You can easily swap the AI model by modifying the `"model"` field in `.github/workflows/ai-unit-test.yml` (Supported options: `gptmini`, `gpt4o`, `deepseek`, `llama`).
- **Code Viewer:** Once the webhook completes, you can view the exact AI-generated unit test code directly inside the popup on the **CI/CD Hook Logs** tab in your Dashboard!
- **Auto-Reload:** The Dashboard tabs will now automatically reload to fetch the latest logs whenever you switch between them.

---

## 🚀 How to Build and Run

### Prerequisites
- Install [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

### Run the Application
You can run the console application from the root directory using the `--project` flag:

```bash
dotnet run --project src/EmployeeManagementDemo
```

Alternatively, navigate into the project directory and run it directly:

```bash
cd src/EmployeeManagementDemo
dotnet run
```

### Build the Project
To compile the project:

```bash
dotnet build
```

---

## 💻 Example Usage

Here is how the service is consumed in `Program.cs`:

```csharp
using EmployeeManagementDemo.Models;
using EmployeeManagementDemo.Services;

var service = new EmployeeService();

// Create new employee records
service.CreateEmployee(new Employee { Id = 1, Name = "Alice", Salary = 50000 });
service.CreateEmployee(new Employee { Id = 2, Name = "Bob", Salary = 60000 });

// Calculate and display annual bonus for Alice
Console.WriteLine(service.GetAnnualBonus(1)); // Output: 5000 (10% of 50000)
```

---

## 🤝 How to Contribute (Commit & PR Guide for Demo)

If you are demonstrating how to contribute to this repository, you can follow these steps:

1. **Create and switch to a new branch**
   ```bash
   git checkout -b feature/your-feature-name
   ```

2. **Make your code changes** (e.g., adding a new feature in `EmployeeService.cs`).

3. **Stage and commit your changes**
   ```bash
   git add .
   git commit -m "Add your descriptive commit message here"
   ```

4. **Push the branch to the remote repository**
   ```bash
   git push -u origin feature/your-feature-name
   ```

5. **Create a Pull Request (PR)**
   - Go to the GitHub repository page.
   - Click the **Compare & pull request** button that automatically appears for your pushed branch.
   - Fill in the PR title and description, then click **Create pull request**.

6. **Wait for CI/CD & Merge (The Gatekeeper)**
   - **Do not merge immediately!** Wait for the GitHub Actions (AI Unit Test Generator) to finish running.
   - Once the AI finishes, it will automatically push the missing unit tests directly into your open PR.
   - Review the AI-generated code. When all checks are green, click **Merge pull request** to safely integrate your code.

---

## 🎓 Graduate Research Project Information

This platform is developed as part of a Master of Engineering (M.Eng.) thesis project at Dhurakij Pundit University.

| Detail | Description |
| :--- | :--- |
| **Research Topic** | A Multi-Agent LLM-Based Approach for Automated Unit Test Generation and Optimization in C# Programs <br> *(แนวทางแบบ Multi-Agent ร่วมกับ Large Language Models สำหรับการสร้างและปรับปรุง Unit Test อัตโนมัติในโปรแกรมภาษา C#)* |
| **Researcher** | **Mr. Attaphon Pungjaree** (Student ID: 645162020028) |
| **Thesis Advisor** | **Dr. Thanaphat Khankajit** |
| **Degree** | Master of Engineering (M.Eng.) |
| **Major** | Artificial Intelligence and Data Engineering |
| **College** | College of Engineering and Technology |
| **University** | **Dhurakij Pundit University** (110/1-4 Prachachuen Road Laksi, Bangkok, 10210) |
| **Contact** | ✉️ Email: [645162020028@dpu.ac.th](mailto:645162020028@dpu.ac.th) <br> 📞 Phone: 095-792-5262 |
