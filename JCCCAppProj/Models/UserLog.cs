using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JCCCAppProj.Models
{
    public class UserLog
    {
        [Key]
        public int  UserLogID {get; set;}

        [DataType(DataType.Date)]
        public Nullable<System.DateTime> LastLoginDate { get; set; }

        [DataType(DataType.Date)]
        public Nullable<System.DateTime> LastApplyDate { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Employer> Employers { get; set; }

    }
}