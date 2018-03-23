using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Entities.Employees;

namespace Employees.Data
{
    public interface IEmployeeRepository : IDisposable
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeByID(Guid employeeId);
        void InsertEmployee(Employee employee);
        void DeleteEmployee(Guid employeeID);
        void UpdateEmployee(Employee employee);
        void Save();
    }
}
