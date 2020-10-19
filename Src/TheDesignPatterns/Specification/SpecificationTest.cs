using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace TheDesignPatterns.Specification
{
    public class SpecificationTest
    {
        private readonly EmployeeService employeeService = new EmployeeService();

        [Fact]
        public void ShouldReturnActiveEmployees()
        {
            ISpecification<Employee> activeEmployeeSpecification = new ActiveEmployeSpecification();

            IEnumerable<Employee> activeEmployees = employeeService.FindEmployees(activeEmployeeSpecification);

            activeEmployees.Should().HaveCount(5);
        }

        [Fact]
        public void ShouldReturnActiveJavaEmployees()
        {
            IEnumerable<ISpecification<Employee>> specifications = employeeService.GetActiveJavaEmployeeSpecifications();

            IEnumerable<Employee> activeJavaEmployees = employeeService.FindEmployees(specifications);

            activeJavaEmployees.Should().HaveCount(2);
        }

        [Fact]
        public void ShoudSendEmailToPerfectEmployees()
        {
            ISpecification<Employee> specification = new SendEmailSpecification();

            employeeService.SendEmailToAllEmployees(specification);
        }

    }
}
