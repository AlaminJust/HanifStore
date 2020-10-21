using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HanifStore.Admin.Models.Role;
using HanifStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace HanifStore.Admin.Controllers
{
    [Route("role")]
    public class RoleManagementController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleManagementController
            (
                IRoleService roleService
            )
        {
            _roleService = roleService;
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
    }
}