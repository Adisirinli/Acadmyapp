using CompanyApp.Business.Services;
using CompanyApp.Domain.Models;
using CompanyAppHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Controller
{
    internal class Controllers
    {

        static Employee _createEmployee(DepartmentService departmentService)
        {
            Helper.ChangeTextColor(ConsoleColor.Yellow, "Enter the employee name ");
            string name = Console.ReadLine();
            Helper.ChangeTextColor(ConsoleColor.Yellow, "Enter the employee surname");
            string surname = Console.ReadLine();
            Helper.ChangeTextColor(ConsoleColor.Yellow, "Enter the employee age");
            byte age;
            bool isParse = byte.TryParse(Console.ReadLine(), out age);
            if (!isParse)
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "Duzgun eded daxil edin");
                return null;
            }
            Helper.ChangeTextColor(ConsoleColor.Yellow, "Enter the employee adress");
            string address = Console.ReadLine();
            Helper.ChangeTextColor(ConsoleColor.Yellow, "Department secin");
        _selectDepartment:
            var department = _selectDepartment(departmentService);
            if (department == null)
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "duzgun secim edin");
                goto _selectDepartment;
            }

            Employee employee = new()
            {
                Name = name,
                Surname = surname,
                Address = address,
                Age = age,
                Department = department,
                DepartmentId = department.Id,
            };
            return employee;
        }
        static Employee _updateEmployee(DepartmentService departmentService, EmployeeService employeeService)
        {
            var employee = _selectEmployee(employeeService);
            if (employee is null)
            {
                return null;
            }
            Helper.ChangeTextColor(ConsoleColor.Yellow, "Enter the employee name");
            string name = Console.ReadLine();
            Helper.ChangeTextColor(ConsoleColor.Yellow, "Enter the employee surname");
            string surname = Console.ReadLine();
            Helper.ChangeTextColor(ConsoleColor.Yellow, "Enter the employee age");
            byte age;
            bool isParse = byte.TryParse(Console.ReadLine(), out age);
            if (!isParse)
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "Duzgun eded daxil edin");
                return null;
            }
            Helper.ChangeTextColor(ConsoleColor.Yellow, "Enter the employee Adress");
            string address = Console.ReadLine();
            Helper.ChangeTextColor(ConsoleColor.Yellow, "Department secin");
        _selectDepartment:
            var department = _selectDepartment(departmentService);
            if (department == null)
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "duzgun secim edin");
                goto _selectDepartment;
            }

            employee.Name = name;
            employee.Surname = surname;
            employee.Age = age;
            employee.Address = address;
            employee.Department = department;
            employee.DepartmentId = department.Id;
            return employee;
        }
        static Employee _deleteEmployee(EmployeeService employeeService)
        {
            Helper.ChangeTextColor(ConsoleColor.Red, "Sileceyiniz Employeeni secin");
            var employee = _selectEmployee(employeeService);
            return employee;
        }
        static Department _createDepartment()
        {
            Helper.ChangeTextColor(ConsoleColor.Yellow, "Department adi daxil edin");
            string name = Console.ReadLine();

            Helper.ChangeTextColor(ConsoleColor.Yellow, "Department capacitysi daxil edin");
            int capacity;
            bool tryParse = int.TryParse(Console.ReadLine(), out capacity);
            if (!tryParse)
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "Duzgun eded daxil edin");
                return null;

            }


            Department department = new()
            {
                Name = name,
                Capacity = capacity

            }
            ;
            return department;
        }
        static Department _updateDepartment(DepartmentService departmentService)
        {
            Helper.ChangeTextColor(ConsoleColor.Yellow, "Department secin");

            var existed = _selectDepartment(departmentService);
            if (existed is null)
                return null;

            Helper.ChangeTextColor(ConsoleColor.Yellow, "Department adi daxil edin");
            string name = Console.ReadLine();
            Helper.ChangeTextColor(ConsoleColor.Yellow, "Department capacitysi daxil edin");
            int capacity;
            bool tryParse = int.TryParse(Console.ReadLine(), out capacity);
            if (!tryParse)
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "Duzgun eded daxil edin");
                return null;

            }
            existed.Capacity = capacity;
            existed.Name = name;
            return existed;

        }
        static Department _deleteDepartment(DepartmentService departmentService)
        {
            Helper.ChangeTextColor(ConsoleColor.Red, "Sileceyiniz Departmenti secin");
            var department = _selectDepartment(departmentService);
            if (department is null)
                return null;
            return department;
        }
        static int _getById()
        {

            Helper.ChangeTextColor(ConsoleColor.Yellow, "enter id:");
        restartId:
            int Id;
            bool tryParse = int.TryParse(Console.ReadLine(), out Id);
            if (!tryParse)
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "Duzgun eded daxil edin:");
                goto restartId;
            }
            return Id;
        }
        static string _search()
        {
            Helper.ChangeTextColor(ConsoleColor.Yellow, "Searching...");
            return Console.ReadLine();
        }

        static void _printDepartments(List<Department> departments)
        {
            foreach (Department department in departments)
            {
                Console.WriteLine(department);
            }
        }
        static void _printEmployees(List<Employee> employees)
        {
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
        static Department _selectDepartment(DepartmentService departmentService)
        {
            var departments = departmentService.GetAll();
            for (int i = 0; i < departments.Count; i++)
            {
                Helper.ChangeTextColor(ConsoleColor.White, $"{departments[i].Id}.{departments[i]}");

            }
            int departmentId;
            bool tryParse = int.TryParse(Console.ReadLine(), out departmentId);
            if (!tryParse)
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "Duzgun eded daxil edin");
                return null;

            }
            var existed = departmentService.Get(departmentId);

            return existed;

        }


        static Employee _selectEmployee(EmployeeService employeeService)
        {
            var employees = employeeService.GetAll();
            for (int i = 0; i < employees.Count; i++)
            {
                Helper.ChangeTextColor(ConsoleColor.White, $"{employees[i].Id}.{employees[i]}");

            }
            int employeeId;
            bool tryParse = int.TryParse(Console.ReadLine(), out employeeId);
            if (!tryParse)
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "Duzgun eded daxil edin");
                return null;

            }
            var existed = employeeService.Get(employeeId);

            return existed;

        }
    }
}
