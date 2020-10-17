using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using HanifStore.Admin.Models;
using HanifStore.Domain;
using HanifStore.Factory;
using HanifStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace HanifStore.Admin.Controllers
{
    [Route("user")]
    public class ManageUsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITransactionModelFactory _transactionModelFactory;
        private readonly ITransactionService _transactionService;

        public ManageUsersController
            (
                IUserService userService,
                ITransactionModelFactory transactionModelFactory,
                ITransactionService transactionService 
            )
        {
            _userService = userService;
            _transactionModelFactory = transactionModelFactory;
            _transactionService = transactionService;
        }
        [Route("list")]
        public IActionResult UserList()
        {
            var usersInfo = _userService.getUsersInformation();
            return View("~/Admin/Views/ManageUsers/UserList.cshtml",usersInfo);
        }
        [Route("create")]
        public IActionResult Create(string userId)
        {
            ViewBag.userName = _userService.getIdentityUserByUserNameOrPhoneNumber(userId:userId).UserName;
            ViewBag.userId = userId;
            return View("~/Admin/Views/ManageUsers/Create.cshtml");
        }
        [Route("create")]
        [HttpPost]
        public IActionResult Create(CustomerBuyModel customersBuy) 
        {
            if (ModelState.IsValid)
            {
                CustomersBuy customerBuy = _transactionModelFactory.CustomerBuyModelFactory(customersBuy , User.Identity.Name);
                _transactionService.InsertCustomerBuy(customerBuy);
            }
            return RedirectToAction("UserList"); 
        }
        [Route("transactions")] // Admin User Both Can See
        [HttpGet]
        public IActionResult TransactionList(string userId)
        {
            var transactionList = _transactionService.getTransactionListByUserId(userId);
            return View("~/Admin/Views/ManageUsers/TransactionList.cshtml",transactionList);
        }
    }
}