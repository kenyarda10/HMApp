using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JCCCAppProj.Models
{
    public class Company
    {
        [Key]
        public int CompanyID { get; set; }

        [Required]
        [StringLength(64)]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [StringLength(200)]
        [Display(Name = "Company Description")]
        public string CompanyDescription { get; set; }

        [Display(Name = "Establishment Date")]
        public Nullable<System.DateTime> EstablishmentDate { get; set; }

        [StringLength(64)]
        [Display(Name = "Company Website")]
        public string CompanyWebsite { get; set; }

        
        public int EmployerID { get; set; }

        public int IndustryID { get; set; }

        public virtual Industry Industry { get; set; }

        public virtual Employer Employer { get; set; }

        public virtual ICollection<CompanyLogo> CompanyLogos { get; set; }
    }
}