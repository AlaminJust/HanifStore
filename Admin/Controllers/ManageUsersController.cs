using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HanifStore.Admin.Controllers
{
    [Route("user")]
    public class ManageUsersController : Controller
    {
        [Route("list")]
        public IActionResult UserList()
        {
            
        }
    }
}