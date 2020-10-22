using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Admin.Models.Role
{
    public class RoleModel
    {
        [Display(Name ="Role name")]
        public string RoleName { get; set; }  
    }
    public class UserAndRole
    {
        public string userId { get; set; }
        public string roleName { get; set; } 
    }
}
