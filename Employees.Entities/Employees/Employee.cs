using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employees.Entities.Employees
{
    public class Employee
    {

        [Key]
        [Column(Order = 1)]
        public Guid EmployeeID { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        [MaxLength(128)]
        public string Address { get; set; }

        [Required]
        [MaxLength(128)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(128)]
        public string EmergencyContactName { get; set; }

        [Required]
        [MaxLength(128)]
        public string EmergencyContactPhoneNumber { get; set; }

        [Required]
        [MaxLength(128)]
        public string JobRole { get; set; }

        [Required]
        [MaxLength(128)]
        public string StartDate { get; set; }

        [Required]
        [MaxLength(128)]
        public string PreviousJob { get; set; }

        [MaxLength(128)]
        public string Documentation { get; set; }

        [MaxLength(128)]
        public string UsefulLinks { get; set; }

        [MaxLength(128)]
        public string Image { get; set; }


    }
}