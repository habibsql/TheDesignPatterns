using System.Collections.Generic;

namespace TheDesignPatterns.Facade
{
    public interface IHRFacade
    {
        IEnumerable<Employee> GetAllEmployees();
        Manager GetManagerById(string id);
        IEnumerable<Department> GetAllDepartments();
    }

    public class HRFacade : IHRFacade
    {
        private readonly IEmployeeService employeeService;
        private readonly IManagerService managerService;
        private readonly IDepartmentService departmentService;

        public HRFacade()
        {
            employeeService = new EmployeeService();
            managerService = new ManagerService();
            departmentService = new DepartmentService();
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return departmentService.GetAllDepartments();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return employeeService.GetAllEmployees();
        }

        public Manager GetManagerById(string id)
        {
            return managerService.GetManagerById(id);
        }
    }

    public interface IEmployeeService
    {
        public IEnumerable<Employee> GetAllEmployees();
    }

    public class EmployeeService : IEmployeeService
    {
        public IEnumerable<Employee> GetAllEmployees()
        {
            return new[]
            {
                new Employee{Id = "E01", Name = "Employee-E01"},
                new Employee{Id = "E02", Name = "Employee-E02"},
                new Employee{Id = "E03", Name = "Employee-E03"},
            };
        }
    }

    public interface IManagerService
    {
        public Manager GetManagerById(string id);
    }

    public class ManagerService : IManagerService
    {
        public Manager GetManagerById(string id)
        {
            return new Manager
            {
                Id = id,
                Name = $"Manager-{id}",
                Age = 45
            };
        }
    }


    public interface IDepartmentService
    {
        public IEnumerable<Department> GetAllDepartments();
    }

    public class DepartmentService : IDepartmentService
    {
        public IEnumerable<Department> GetAllDepartments()
        {
           var managerIT = new Manager
            {
                Id = "M01",
                Name = $"Manager-M01",
                Age = 45
            };
            var managerFi = new Manager
            {
                Id = "M02",
                Name = $"Manager-M02",
                Age = 50
            };

            return new[]
            {
                new Department{Id = "D01", Name = "IT", Manager = managerIT},
                new Department{Id = "D02", Name = "Finance", Manager = managerFi},
            };
        }
    }

    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class Department
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Manager Manager { get; set; }
    }

    public class Manager : Employee
    {
        public int Age { get; set; }
    }
}
