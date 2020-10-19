using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace TheDesignPatterns.Repository
{
    public class NoSqlRepositoryTest
    {
        private readonly NoSqlEmployeeRepository noSqlEmployeeRepository = new NoSqlEmployeeRepository();

        [Fact]
        public void ShouldReturnEmployeeWhenValidEmployeeIdProvided()
        {
            Employee emp = noSqlEmployeeRepository.FindById("001");

            emp.Should().NotBeNull();
            emp.Id.Should().Be("001");
        }

        [Fact]
        public void ShouldReturnEmployeesWhenValidDepartmentIdProvided()
        {
            string departmentId = "D001";

            IEnumerable<Employee> employees = noSqlEmployeeRepository.FindEmployees(departmentId);

            employees.Should().HaveCount(2);
        }

        [Fact]
        public void ShouldSaveEmployee()
        {
            var employee = new Employee { Id = "E001", Name = "Employee-001" };

            noSqlEmployeeRepository.Save(employee);
        }

    }

    public class SqlRepositoryTest
    {
        private readonly SqlEmployeeRepository sqlEmployeeRepository = new SqlEmployeeRepository();

        [Fact]
        public void ShouldReturnEmployeeWhenValidEmployeeIdProvided()
        {
            Employee emp = sqlEmployeeRepository.FindById("001");

            emp.Should().NotBeNull();
            emp.Id.Should().Be("001");
        }

        [Fact]
        public void ShouldReturnEmployeesWhenValidDepartmentIdProvided()
        {
            string departmentId = "D001";

            IEnumerable<Employee> employees = sqlEmployeeRepository.FindEmployees(departmentId);

            employees.Should().HaveCount(2);
        }

        [Fact]
        public void ShouldSaveEmployee()
        {
            var employee = new Employee { Id = "E001", Name = "Employee-001" };

            sqlEmployeeRepository.Save(employee);
        }

    }
}
