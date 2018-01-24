using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employees.Entities.Employees
{
    public class Employee
    {

        [Key]
        [Column(Order = 1)]
        [Display(Name = "Employee Number")]
        public Guid EmployeeID { get; set; }

        [Required]
        [MaxLength(128)]
        [Display(Name = "Employee Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(128)]
        [Display(Name = "Employee Address")]
        public string Address { get; set; }

        [Required]
        [MaxLength(128)]
        [Display(Name = "Employee Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(128)]
        [Display(Name = "Emergency Contact Name")]
        public string EmergencyContactName { get; set; }

        [Required]
        [MaxLength(128)]
        [Display(Name = "Emergency Contact Phone Number")]
        public string EmergencyContactPhoneNumber { get; set; }

        [Required]
        [MaxLength(128)]
        [Display(Name = "Job Role")]
        public string JobRole { get; set; }

        [Required]
        [MaxLength(128)]
        [Display(Name = "Start Date")]
        public string StartDate { get; set; }

        [Required]
        [MaxLength(128)]
        [Display(Name = "Previous Job")]
        public string PreviousJob { get; set; }

        [MaxLength(128)]
        [Display(Name = "Documentation")]
        public string Documentation { get; set; }

        [MaxLength(128)]
        [Display(Name = "Useful Links(Git Repository, LinkedIn Profile, etc.)")]
        public string UsefulLinks { get; set; }

        [MaxLength(128)]
        [Display(Name = "Image")]
        public string Image { get; set; }


    }
}