using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HanifStore.Client.Models;
using HanifStore.Domain;
using HanifStore.Factory;
using HanifStore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HanifStore.Client.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userLoginRegistrationService;
        private readonly ILoginRegistrationModelFactory _loginRegistrationModelFactory;

        public UsersController(
            IUserService userLoginRegistrationService,
            ILoginRegistrationModelFactory loginRegistrationModelFactory
            )
        {
            _userLoginRegistrationService = userLoginRegistrationService;
            _loginRegistrationModelFactory = loginRegistrationModelFactory;
        }
        public ActionResult Registration()
        {
            return View("~/Client/Views/Users/Registration.cshtml"); 
        }
        [HttpPost]
        public async Task<IActionResult> Registration(Registration model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && _userLoginRegistrationService.checkDuplicateUser(model))
                    { 
                        var result = await _userLoginRegistrationService.userRegistration(model);
                        if (result.Succeeded)
                        {
                            UserInformation userInformation = _loginRegistrationModelFactory.userInformationModelFactory(model, User.Identity.Name);
                            var user = _userLoginRegistrationService.InsertUserInformation(userInformation);
                            return RedirectToAction("Index","Home");
                        }
                        else
                        {
                            foreach(var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Username or phone number already exist.");
                    }
                }
                return View("~/Client/Views/Users/Registration.cshtml",model);
            }
            catch
            {
                throw new NullReferenceException(nameof(model));
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    var result = await _userLoginRegistrationService.userLogin(model);
                    if (result)
                    {
                        return Json(new { result = "Redirect", url = Url.Action("index", "home") });
                    }
                    else
                    {
                        return BadRequest(Json(new { result = "Username or password is not match." }));
                    }
                }
                else
                {
                    return BadRequest(Json(new { result = "Username or password is not match." }));
                }
            }
            else
            {
                return BadRequest(Json(new { result = "Username or password is not match." }));
            }
        }
        public IActionResult Logout()
        {
            _userLoginRegistrationService.userLogout();
            return RedirectToAction("Index", "Home");
        }
    }
}