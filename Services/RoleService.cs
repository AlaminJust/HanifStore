using HanifStore.Admin.Models.Role;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserService _userService;
        private readonly UserManager<IdentityUser> _userManager;

        public RoleService
            (
                RoleManager<IdentityRole> roleManager,
                IUserService userService,
                UserManager<IdentityUser>userManager
            )
        {
            _roleManager = roleManager;
            _userService = userService;
            _userManager = userManager;
        }
        #region utilities

        private bool isRoleNameExist(string roleName)
        {
            if(roleName == null)
            {
                throw new NullReferenceException(nameof(roleName));
            }
            return _roleManager.Roles.Where(x => x.Name.ToLower().Trim() == roleName.ToLower().Trim()).Any();
        }

        #endregion
        public async Task<IdentityResult> insertRole(RoleModel model) 
        {
            if(model == null)
            {
                throw new NullReferenceException(nameof(model));
            }
            if (isRoleNameExist(model.RoleName))
            {
                return new IdentityResult();
            }
            IdentityRole identityRole = new IdentityRole
            {
                Name = model.RoleName
            };
            var result = await _roleManager.CreateAsync(identityRole);
            return result; 
        }

        public void insertUserRole(string userId, string roleName)
        {
            if(userId == null)
            {
                throw new NullReferenceException(nameof(userId)); 
            } 
            if(roleName == null)
            {
                throw new NullReferenceException(nameof(roleName));
            }
            var role = _roleManager.FindByNameAsync(roleName.ToLower().Trim());
            if(role == null)
            {
                throw new NullReferenceException(nameof(role));
            }
            var user = _userService.getIdentityUserByUserNameOrPhoneNumber(userId: userId);
            if(user == null)
            {
                throw new NullReferenceException(nameof(user));
            }
            var result = _userManager.AddToRoleAsync(user, roleName.ToLower().Trim());
            result.Wait();
        }

        public IList<RoleListModel> getAllRole()
        {
            return _roleManager.Roles.Select(x => new RoleListModel
            {
                RoleId = x.Id, 
                RoleName = x.Name
            }).ToList();
        }
    }
}
