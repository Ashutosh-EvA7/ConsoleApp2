using System;

public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public double Salary { get; set; }
    public string Position { get; set; }
    public DateTime dt { get; set; }
    public Employee(int id, string name, string position, double salary, DateTime t)
    {
        EmployeeId = id;
        Name = name;
        Position = position;
        Salary = salary;
        dt = t;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create an array of 5 employee objects
        Employee[] employees = new Employee[5];

        // Store employee details in the array
        employees[0] = new Employee(1, "Rajat", "Sales", 50000.00, new DateTime(2024, 1, 20));
        employees[1] = new Employee(2, "Saloni", "Marketing", 59000.00, new DateTime(2024, 2, 2));
        employees[2] = new Employee(3, "Rakesh", "IT", 35000.00, new DateTime(2024, 3, 29));
        employees[3] = new Employee(4, "Manas", "HR", 42000.00, new DateTime(2024, 4, 10));
        employees[4] = new Employee(5, "Prajyot", "Accounting", 65000.00, new DateTime(2024, 6, 7));
        Console.WriteLine("\nList of all Employees:");

        // Print the employee details
        foreach (Employee employee in employees)
        {
            Console.WriteLine("Id: {0}, Name: {1}, Position: {2}, Salary: {3}, Join Date: {4}", employee.EmployeeId, employee.Name, employee.Position, employee.Salary, employee.dt);
        }
        DisplaySecondHighestSalary(employees);
        DisplayEmployeesInDateRange(employees, new DateTime(2024, 1, 1), new DateTime(2024, 3, 31));
        Employee newEmployee = AddEmployee(employees);
        Console.WriteLine("\nUpdated list of employees:");
        for (int i = 0; i < employees.Length; i++)
        {
            Console.WriteLine("Id: {0}, Name: {1}, Position: {2}, Salary: {3}, Join Date: {4}", employees[i].EmployeeId, employees[i].Name, employees[i].Position, employees[i].Salary, employees[i].dt);
        }

        // Add the new employee to the end of the array
        Array.Resize(ref employees, employees.Length + 1);
        employees[employees.Length - 1] = newEmployee;

        // Display the updated employee list with the new employee
        Console.WriteLine("\nUpdated list of employees with the new employee:");
        Array.Sort(employees, (x, y) => x.EmployeeId.CompareTo(y.EmployeeId));
        foreach (Employee employee in employees)
        {
            Console.WriteLine("Id: {0}, Name: {1}, Position: {2}, Salary: {3}, Join Date: {4}", employee.EmployeeId, employee.Name, employee.Position, employee.Salary, employee.dt);
        }
        UpdateEmployeeSalaryAndPosition(employees);
        Console.WriteLine("\nUpdated list of all Employees:");
        Array.Sort(employees, (x, y) => x.EmployeeId.CompareTo(y.EmployeeId));
        foreach (Employee employee in employees)
        {
            Console.WriteLine("Id: {0}, Name: {1}, Position: {2}, Salary: {3}, Join Date: {4}", employee.EmployeeId, employee.Name, employee.Position, employee.Salary, employee.dt);
        }
    }
    public static void DisplaySecondHighestSalary(Employee[] employees)
    {
        Array.Sort(employees, (x, y) => y.Salary.CompareTo(x.Salary));
        Employee secondHighestSalaryEmployee = employees[1];

        Console.WriteLine("\nEmployee with the 2nd highest salary:");
        Console.WriteLine("Id: {0}, Name: {1}, Position: {2}, Salary: {3}, Join Date: {4}", secondHighestSalaryEmployee.EmployeeId, secondHighestSalaryEmployee.Name, secondHighestSalaryEmployee.Position, secondHighestSalaryEmployee.Salary, secondHighestSalaryEmployee.dt);
    }
    public static Employee AddEmployee(Employee[] employees)
    {
        Console.WriteLine("\nAdd new employee details:");
        Console.Write("Enter the employee ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the employee name: ");
        string name = Console.ReadLine();

        Console.Write("Enter the employee position: ");
        string position = Console.ReadLine();

        Console.Write("Enter the employee salary: ");
        double salary = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the employee join date (yyyy-MM-dd): ");
        string dateInput = Console.ReadLine();
        DateTime date = Convert.ToDateTime(dateInput);

        Employee newEmployee = new Employee(id, name, position, salary, date);

        Console.WriteLine("New employee added:");
        return newEmployee;
    }
    public static void DisplayEmployeesInDateRange(Employee[] employees, DateTime startDate, DateTime endDate)
    {
        Console.WriteLine("\nEmployees who joined between " + startDate.ToString("yyyy-MM-dd") + " and " + endDate.ToString("yyyy-MM-dd") + ":");
        Array.Sort(employees, (x, y) => x.EmployeeId.CompareTo(y.EmployeeId));
        foreach (Employee employee in employees)
        {
            if (employee.dt >= startDate && employee.dt <= endDate)
            {
                Console.WriteLine("Id: {0}, Name: {1}, Position: {2}, Salary: {3}, Join Date: {4}", employee.EmployeeId, employee.Name, employee.Position, employee.Salary, employee.dt);
            }
        }
    }
    public static void UpdateEmployeeSalaryAndPosition(Employee[] employees)
    {
        Array.Sort(employees, (x, y) => x.Salary.CompareTo(y.Salary));
        employees[0].Position = "Junior " + employees[0].Position;
        employees[0].Salary = 40000.00;
    }
}