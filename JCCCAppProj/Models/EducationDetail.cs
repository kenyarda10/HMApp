using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JCCCAppProj.Models
{
    public class EducationDetail
    {
        [Key]
        public int EducationDetailID { get; set; }

        [StringLength(64)]
        [Display(Name = "Certificate/Degree")]
        public string CertificateDegree { get; set; }

        [StringLength(64)]
        [Display(Name = "Major")]
        public string Major { get; set; }

        [StringLength(64)]
        [Display(Name = "Institution Name")]
        public string InstitutionName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public Nullable<System.DateTime> StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Completion Date")]
        public Nullable<System.DateTime> CompletionDate { get; set; }

        [Display(Name = "Percentage")]
        public int Percentage { get; set; }

        [Display(Name = "GPA")]
        public int GPA { get; set; }

        public int StudentID { get; set; }

        public virtual Student Student { get; set; }

    }
}