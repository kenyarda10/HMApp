using JCCCAppProj.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JCCCAppProj.ViewModel
{
    public class SearchViewModel
    {

        [StringLength(64)]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [StringLength(64)]
        [Display(Name = "Company Website")]
        public string CompanyWebsite { get; set; }

        [StringLength(64)]
        [Display(Name = "Industry")]
        public string IndustryName { get; set; }

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
        public Nullable<int> NumOpenings { get; set; }

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



        public Int32 Page { get; set; }
        public Int32 PageSize { get; set; }
        public String Sort { get; set; }
        public String SortDir { get; set; }
        public Int32 TotalRecords { get; set; }

        public virtual IEnumerable<Company> Companies { get; set; }
        public virtual IEnumerable<Employer> Employer { get; set; }


        public IEnumerable<JobPosting> JobPostings { get; set; }
       


        public SearchViewModel()
        {
            Page = 1;
            PageSize = 2;
            Sort = "createdDate";
            SortDir = "DESC";

        }

    }
}

    
