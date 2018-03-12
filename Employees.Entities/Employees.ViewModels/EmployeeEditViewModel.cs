using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Employees.Entities.Employees.ViewModels
{
    public class EmployeeEditViewModel
    {

        [Display(Name = "Employee Number")]
        public string EmployeeID { get; set; }

        [Display(Name = "Employee Name")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Employee Address")]
        public string Address { get; set; }

        [Display(Name = "Employee Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Emergency Contact Name")]
        public string EmergencyContactName { get; set; }

        [Display(Name = "Emergency Contact Phone Number")]
        public string EmergencyContactPhoneNumber { get; set; }

        [Display(Name = "Job Role")]
        public string JobRole { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Previous Job")]
        public string PreviousJob { get; set; }

        [Display(Name = "Documentation")]
        public string Documentation { get; set; }

        [Display(Name = "Useful Links(Git Repository, LinkedIn Profile, etc.)")]
        public string UsefulLinks { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }

    }
}