using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HanifStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace HanifStore.Admin.Controllers
{
    [Route("user")]
    public class ManageUsersController : Controller
    {
        private readonly IUserService _userService;

        public ManageUsersController
            (
                IUserService userService
            )
        {
            _userService = userService;
        }
        [Route("list")]
        public IActionResult UserList()
        {
            var usersInfo = _userService.getUsersInformation();
            return View("~/Admin/Views/ManageUsers/UserList.cshtml",usersInfo);
        }
    }
}