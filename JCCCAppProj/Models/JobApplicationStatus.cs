using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JCCCAppProj.Models
{
    public class JobApplicationStatus
    {
        [Key]
        public int JobApplicationStatusID { get; set; }

        [StringLength(64)]
        [Display(Name = "Status Description")]
        public string StatusDesc { get; set; }

        public int StudentID { get; set; }

        public virtual Student Student { get; set; }
    }
}