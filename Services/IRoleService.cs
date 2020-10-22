using HanifStore.Admin.Models.Role;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Services
{
    public interface IRoleService
    {
        public Task<IdentityResult> insertRole(RoleModel roleName);
        public Task<Boolean> insertUserRole(string userId, string roleName);
        public IList<RoleListModel> getAllRole();
        public Task<Boolean> IsUserInSpecificRole(string userId, string roleName); 
        public Task<Boolean> removeUserRole(string userId, string roleName);  
    }
}
