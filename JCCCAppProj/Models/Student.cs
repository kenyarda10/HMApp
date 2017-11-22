using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JCCCAppProj.Models
{
    public class Student
    {
        public Student() { }

        [Key]
        public int StudentID { get; set; }


        public Student (ApplicationUser appUser)
        {
            Id = appUser.Id;


        }

        [Required]
        public string Id { get; set; }

        public byte[] StudentImageData { get; set; }

        public string StudentImageMimeType { get; set; }

        public virtual ICollection<EducationDetail> EducationDetails { get; set; }
        public virtual ICollection<JobApplicationStatus> JobApplicationStatuses { get; set; }
        public virtual ICollection<UserLog> UserLog { get; set; }
    }
}