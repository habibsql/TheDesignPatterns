using System;
using System.Collections.Generic;

namespace TheDesignPatterns.Repository
{
    public abstract class EntityBase
    {
        public string Id { get; set; }

        public DateTime CreatedDate => DateTime.UtcNow;
    }

    public class Employee : EntityBase
    {
        public string Name { get; set; }
    }

    public class User : EntityBase
    {
        public string Email { get; set; }
    }

    /// <summary>
    /// Generic Repository for all Data source
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : EntityBase
    {
        T FindById(string id);

        void Save(T entity);
    }

    
    /// <summary>
    /// Nosql database specific Employee Repository
    /// </summary>
    public interface INoSqlEmployeeRepository : IRepository<Employee>
    {
        IEnumerable<Employee> FindEmployees(string departmentId);
    }

    /// <summary>
    /// Sql database specific employee repository
    /// </summary>
    public interface ISqlEmployeeRepository : IRepository<Employee>
    {
        IEnumerable<Employee> FindEmployees(string departmentId);
    }

    /// <summary>
    /// Concreate Employee repository for NosqlDatabase
    /// </summary>
    public class NoSqlEmployeeRepository : INoSqlEmployeeRepository
    {
        public Employee FindById(string id)
        {
            return new Employee { Id = id, Name = $"Name-{id}" };
        }

        public IEnumerable<Employee> FindEmployees(string departmentId)
        {
            return new[] { new Employee { Id = "E01", Name = "Name-01" }, new Employee { Id = "E02", Name = "Name-02" } };
        }

        public void Save(Employee entity)
        {
            // Save the employee...
        }
    }

    /// <summary>
    /// Concreate Employee repository for sqlDatabase
    /// </summary>
    public class SqlEmployeeRepository : ISqlEmployeeRepository
    {
        public Employee FindById(string id)
        {
            return new Employee { Id = id, Name = $"Name-{id}" };
        }

        public IEnumerable<Employee> FindEmployees(string departmentId)
        {
            return new[] { new Employee { Id = "E01", Name = "Name-01" }, new Employee { Id = "E02", Name = "Name-02" } };
        }

        public void Save(Employee entity)
        {
            // Save the employee...
        }
    }
}
