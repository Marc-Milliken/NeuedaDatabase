using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Employees.Entities.Employees;
using Employees.Entities.Employees.ViewModels;

namespace Employees.Data
{
    public class EmployeeRepository
    {
        public List<EmployeeDisplayViewModel> GetEmployees()
        {
            using (var context = new ApplicationDbContext())
            {
                List<Employee> employees = new List<Employee>();
                employees = context.Employees.AsNoTracking().ToList();
                
                if (employees != null)
                {
                    List<EmployeeDisplayViewModel> employeesDisplay = new List<EmployeeDisplayViewModel>();
                    foreach (var x in employees)
                    {
                        var employeeDisplay = new EmployeeDisplayViewModel()
                        {
                            EmployeeID = x.EmployeeID,
                            Name = x.Name,
                            DateOfBirth = x.DateOfBirth,
                            Address = x.Address,
                            PhoneNumber = x.PhoneNumber,
                            EmergencyContactName = x.EmergencyContactName,
                            EmergencyContactPhoneNumber = x.EmergencyContactPhoneNumber,
                            JobRole = x.JobRole,
                            StartDate = x.StartDate,
                            PreviousJob = x.PreviousJob,
                            Documentation = x.Documentation,
                            UsefulLinks = x.UsefulLinks,
                            Image = x.Image
                        };
                        employeesDisplay.Add(employeeDisplay);
                    }
                    return employeesDisplay;
                }
                return null;
            }
        }

        public EmployeeEditViewModel CreateEmployee()
        {
            var employee = new EmployeeEditViewModel()
            {
                EmployeeID = Guid.NewGuid().ToString(),
            };
            return employee;
        }

        public bool SaveEmployee(EmployeeEditViewModel employeeedit)
        {
            if (employeeedit != null)
            {
                using (var context = new ApplicationDbContext())
                {
                    if (Guid.TryParse(employeeedit.EmployeeID, out Guid newGuid))
                    {
                        var employee = new Employee()
                        {
                            EmployeeID = newGuid,
                            Name = employeeedit.Name,
                            DateOfBirth = employeeedit.DateOfBirth,
                            Address = employeeedit.Address,
                            PhoneNumber = employeeedit.PhoneNumber,
                            EmergencyContactName = employeeedit.EmergencyContactName,
                            EmergencyContactPhoneNumber = employeeedit.EmergencyContactPhoneNumber,
                            JobRole = employeeedit.JobRole,
                            StartDate = employeeedit.StartDate,
                            PreviousJob = employeeedit.PreviousJob,
                            Documentation = employeeedit.Documentation,
                            UsefulLinks = employeeedit.UsefulLinks,
                            Image = employeeedit.Image
                        };

                        context.Employees.Add(employee);
                        context.SaveChanges();
                        return true;
                    }
                }
            }
            // Return false if employeeedit == null or EmployeeID is not a guid
            return false;
        }
    }
}

