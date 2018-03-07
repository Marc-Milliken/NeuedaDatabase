using Employees.Entities.Employees;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Employees.Entities.Images
{
    public class Image
    {

        [Key]
        [Column(Order = 1)]
        [Display(Name = "Image Number")]
        public Guid ImageID { get; set; }

        [MaxLength(128)]
        [Display(Name = "Image Name")]
        public string ImageName { get; set; }

        [MaxLength(128)]
        [Display(Name = "Image Upload")]
        public string UploadImage { get; set; }


        public virtual Employee EmployeeID { get; set; }
    }
}