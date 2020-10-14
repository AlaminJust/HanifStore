using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HanifStore.Client.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HanifStore.Client.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Registration()
        {
            return View("~/Client/Views/Users/Registration.cshtml"); 
        }
        [HttpPost]
        public ActionResult Registration(Registration model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                }
            }
            catch
            {
                
            }
            return View();
        }
    }
}