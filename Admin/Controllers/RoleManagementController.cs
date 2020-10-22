using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HanifStore.Admin.Models;
using HanifStore.Admin.Models.Role;
using HanifStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace HanifStore.Admin.Controllers
{
    [Route("role")]
    public class RoleManagementController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;

        public RoleManagementController
            (
                IRoleService roleService,
                IUserService userService
            )
        {
            _roleService = roleService;
            _userService = userService;
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Role(RoleModel model)
        {
            if (ModelState.IsValid)
            {
               var result = await _roleService.insertRole(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("list", "role");
                }
            }
            return RedirectToAction("list","role");
        }

        [Route("list")]
        public IActionResult RoleList()
        {
            var roleList = _roleService.getAllRole().ToList();
            var model = new RoleAndRoleListModel();
            model.roleListModels = roleList;
            return View("~/Admin/Views/RoleManagement/RoleList.cshtml", model);
        }
        [Route("control")]
        public IActionResult RoleControl()
        {
            var roleAndUserListModel = new RoleAndUserListModel();
            roleAndUserListModel.usersInformationModels = _userService.getUsersInformation();
            roleAndUserListModel.roleListModel = _roleService.getAllRole();
            return View("~/Admin/Views/RoleManagement/RoleControl.cshtml", roleAndUserListModel);
        }
        [HttpPost]
        [Route("createRole")]
        public async Task<IActionResult> AddOrRemoveUsersRole(UserAndRole model) 
        {
            if(await _roleService.insertUserRole(model.userId, model.roleName))
            {
                return Json(new { result = "User role added.", url = Url.Action("control", "role") });
            }
            else if(await _roleService.removeUserRole(model.userId, model.roleName))
            {
                return Json(new { result = "User role removed.", url = Url.Action("control", "role") });

            }
            else return BadRequest(Json(new { error = "Already is in role" }));
        }
    }
}