using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Employees.Entities.Employees.ViewModels
{
    public partial class DocumentDisplayViewModel
    {

        [Display(Name = "Document Number")]
        public Guid DocumentID { get; set; }

        [Display(Name = "Document Name")]
        public string Name { get; set; }

        [Display(Name = "Document Content")]
        public byte[] Content { get; set; }

    }
}