using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JCCCAppProj.Models
{
    public class JobPosting
    {
        [Key]
        public int JobPostingID { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]
        public Nullable<System.DateTime> createdDate { get; set; }

        [StringLength(75)]
        [Display(Name = "Job Description")]
        public string JobDescription { get; set; }

        [StringLength(64)]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Display(Name = "Number of Openings")]
        public Nullable <int> NumOpenings { get; set; }

        [Display(Name = "Hours Per Week")]
        public Nullable<int> HoursPerWeek { get; set; }

        [Display(Name = "Salary")]
        public Nullable<decimal> WageSalary { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public Nullable<System.DateTime> StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public Nullable<System.DateTime> EndDate { get; set; }

        [StringLength(300)]
        [Display(Name = "Job Qualifications")]
        public string Qualifications { get; set; }

        [StringLength(100)]
        [Display(Name = "Application Instructions")]
        public string ApplicationInstructions { get; set; }

        [StringLength(64)]
        [Display(Name = "Application Website")]
        public string ApplicationWebsite { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Expiration Date")]
        public Nullable<System.DateTime> ExpirationDate { get; set; }

        [StringLength(64)]
        [Display(Name = "Job Type")]
        public string JobType { get; set; }

        [ForeignKey("Industry")]
        public int IndustryID { get; set; }
        public virtual Industry Industry { get; set; }

        [ForeignKey("Employer")]
        public int EmployerID { get; set; }
        public virtual Employer Employer { get; set; }
        

    }
}