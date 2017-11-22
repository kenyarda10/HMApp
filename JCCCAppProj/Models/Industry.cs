using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JCCCAppProj.Models
{
    public class Industry
    {
        [Key]
        public int IndustryID { get; set; }

        [StringLength(64)]
        [Display(Name = "Industry")]
        public string IndustryName { get; set; }

        

        public virtual ICollection<Company> Companies { get; set; }
        
    }
}