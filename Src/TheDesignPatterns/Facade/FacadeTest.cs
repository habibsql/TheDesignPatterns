using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace TheDesignPatterns.Facade
{
    public class FacadeTest
    {
        private readonly IHRFacade hrFacade = new HRFacade();

        [Fact]
        public void SholdWork()
        {
            IEnumerable<Department> departments = hrFacade.GetAllDepartments();
            IEnumerable<Employee> employees = hrFacade.GetAllEmployees();
            Manager manager = hrFacade.GetManagerById("M01");

            departments.Should().HaveCount(2);
            employees.Should().HaveCount(3);
            manager.Should().NotBeNull();
        }
    }
}
