using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JCCCAppProj.Models
{
    public class Employer
    {
        public Employer ()
            {

            }

        [Key]
        public int EmployerID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employer(ApplicationUser appUser)
        {
            Id = appUser.Id;

            this.JobPostings = new HashSet<JobPosting>();

        }

        [Required]
        public string Id { get; set; }

        public byte[] EmployerImageData { get; set; }

        public string EmployerImageMimeType { get; set; }

        
        [ForeignKey("UserLog")]
        public int UserLogID { get; set; }
        public virtual UserLog UserLog { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Company> Companies { get; set; }

        

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobPosting> JobPostings { get; set; }
              

       

        
    }
}