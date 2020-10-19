using System.Collections.Generic;
using System.Diagnostics;

namespace TheDesignPatterns.Specification
{

    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Department { get; set; }

        public bool Active { get; set; }
    }

    /// <summary>
    /// Composit specification can also possible by adding AND OR specification.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISpecification<T> where T : class
    {
        bool IsSatisfiedBy(T employee);
    }


    public class ActiveEmployeSpecification : ISpecification<Employee>
    {
        public bool IsSatisfiedBy(Employee employee)
        {
            return employee.Active;
        }
    }

    public class JavaEmployeSpecification : ISpecification<Employee>
    {
        public bool IsSatisfiedBy(Employee employee)
        {
            return employee.Department.Equals("Java");
        }
    }

    public class SendEmailSpecification : ISpecification<Employee>
    {
        public bool IsSatisfiedBy(Employee employee)
        {
            return employee.Active && (employee.Department == "C#" || employee.Department == "Python");
        }
    }

    public class EmployeeService
    {
        private readonly IList<Employee> employees = new List<Employee>();

        public EmployeeService()
        {
            employees.Add(new Employee { Id = 1, Name = "Employee-1", Department = "C#", Active = true });
            employees.Add(new Employee { Id = 2, Name = "Employee-2", Department = "C#", Active = true });
            employees.Add(new Employee { Id = 3, Name = "Employee-3", Department = "Java", Active = true });
            employees.Add(new Employee { Id = 4, Name = "Employee-4", Department = "Java", Active = true });
            employees.Add(new Employee { Id = 5, Name = "Employee-5", Department = "Python", Active = true });
            employees.Add(new Employee { Id = 6, Name = "Employee-6", Department = "Python", Active = false });
        }

        /// <summary>
        /// Find the employees who meet the specification
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> FindEmployees(ISpecification<Employee> specification)
        {
            var localEmployees = new List<Employee>();

            foreach (Employee employee in employees)
            {
                if (specification.IsSatisfiedBy(employee))
                {
                    localEmployees.Add(employee);
                }
            }

            return localEmployees;
        }

        /// <summary>
        /// Find the employees who meet the specifications
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> FindEmployees(IEnumerable<ISpecification<Employee>> specifications)
        {
            var localEmployees = new List<Employee>();

            foreach (Employee employee in employees)
            {
                var satisfied = true;

                foreach (ISpecification<Employee> specification in specifications)
                {
                    satisfied = specification.IsSatisfiedBy(employee);
                    if (!satisfied)
                    {
                        satisfied = false;
                        break;
                    }
                }

                if (satisfied)
                {
                    localEmployees.Add(employee);
                }
            }

            return localEmployees;
        }

        /// <summary>
        /// Send email to those employees who has satisfied condition
        /// </summary>
        public void SendEmailToAllEmployees(ISpecification<Employee> emailSendingSpeicication)
        {
            foreach (Employee employee in employees)
            {
                bool satisfied = emailSendingSpeicication.IsSatisfiedBy(employee);
                if (satisfied)
                {
                    SendEmail(employee);
                }
            }
        }

        /// <summary>
        /// Provide EmployeeSpecifications for ActiveJava employees
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ISpecification<Employee>> GetActiveJavaEmployeeSpecifications()
        {
            var list = new List<ISpecification<Employee>>();
            list.Add(new ActiveEmployeSpecification());
            list.Add(new JavaEmployeSpecification());

            return list;
        }

        /// <summary>
        /// Email Sending Helper
        /// </summary>
        /// <param name="employee"></param>
        private void SendEmail(Employee employee)
        {
            Debug.WriteLine($"Email Sending to Employee Id={employee.Id}");
        }
    }
}
