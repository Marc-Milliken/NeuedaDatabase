using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Employees.Entities.Documents
{
    public class Document
    {

        [Key]
        [Column(Order = 1)]
        [Display(Name = "Document Number")]
        public Guid DocumentID { get; set; }

        
        [MaxLength(128)]
        [Display(Name = "Document Name")]
        public string Name { get; set; }

        
        [MaxLength(128)]
        [Display(Name = "Document Content")]
        public byte[] Content { get; set; }


    }
}