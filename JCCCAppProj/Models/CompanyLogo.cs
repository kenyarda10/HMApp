using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JCCCAppProj.Models
{
    public class CompanyLogo
    {
        [Key]
        public int CompanyLogoID { get; set; }

        [StringLength(64)]
        [Display(Name = "Company Logo Name")]
        public string CompanyLogoName { get; set; }

        public byte[] CompanyImageData { get; set; }

        public int CompanyID { get; set; }

       

        public virtual Company Company { get; set; }

       
    }
}