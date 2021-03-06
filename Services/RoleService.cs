﻿using HanifStore.Admin.Models.Role;
using HanifStore.Data;
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
            return _roleManager.Roles.Where(x => x.Name.Trim() == roleName.Trim()).Any();
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
                Name = model.RoleName.Trim()
            };
            var result = await _roleManager.CreateAsync(identityRole);
            return result;
        }

        public async Task<bool> insertUserRole(string userId, string roleName)
        {
            if(userId == null)
            {
                throw new NullReferenceException(nameof(userId)); 
            } 
            if(roleName == null)
            {
                throw new NullReferenceException(nameof(roleName));
            }
            var role = await _roleManager.FindByNameAsync(roleName.Trim());
            if(role == null)
            {
                throw new NullReferenceException(nameof(role));
            }
            var user = _userService.getIdentityUserByUserNameOrPhoneNumber(userId: userId);
            if(user == null)
            {
                throw new NullReferenceException(nameof(user));
            }
            if (await IsUserInSpecificRole(userId, roleName.Trim())) return false;
            var restult = await _userManager.AddToRoleAsync(user, roleName.Trim());
            if (restult.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public IList<RoleListModel> getAllRole()
        {
            return _roleManager.Roles.Select(x => new RoleListModel
            {
                RoleId = x.Id,
                RoleName = x.Name
            }).ToList();
        }
        public async Task<Boolean> IsUserInSpecificRole(string userId , string roleName) 
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null) return false;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return false;
            return await _userManager.IsInRoleAsync(user, role.Name);
        }

        public async Task<bool> removeUserRole(string userId, string roleName)
        {
            if (userId == null)
            {
                throw new NullReferenceException(nameof(userId));
            }
            if (roleName == null)
            {
                throw new NullReferenceException(nameof(roleName));
            }
            var role = await _roleManager.FindByNameAsync(roleName.Trim());
            if (role == null)
            {
                throw new NullReferenceException(nameof(role));
            }
            var user =  _userService.getIdentityUserByUserNameOrPhoneNumber(userId: userId);
            if (user == null)
            {
                throw new NullReferenceException(nameof(user));
            }
            if (!await IsUserInSpecificRole(userId, roleName.Trim())) return false;
            var result = await _userManager.RemoveFromRoleAsync(user, roleName.Trim());
            if (result.Succeeded)
            {
                return true;
            }
            else return false;
        }

    }
}
