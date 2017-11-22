using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JCCCAppProj.Models
{
    public class RoleViewModel
    {
        public RoleViewModel() { }

        public RoleViewModel(ApplicationRole appRole)
        {
            Id = appRole.Id;
            Name = appRole.Name;

        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}