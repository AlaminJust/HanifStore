using HanifStore.Client.Models;
using HanifStore.Domain;
using HanifStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Factory
{
    public class LoginRegistrationModelFactory : ILoginRegistrationModelFactory
    {
        private readonly IUserService _userService;

        public LoginRegistrationModelFactory
            (
                IUserService userService
            )
        {
            _userService = userService;
        }
        public UserInformation userInformationModelFactory(Registration model , string userName)
        {
            var user = _userService.getIdentityUserByUserNameOrPhoneNumber(userName);
            var Userinfo = new UserInformation
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password,
                ConfirmPassword = model.ConfirmPassword,
                Amount = 0,
                Email = model.Email,
                FatherName = model.FatherName,
                IdentityUser = user,
                UserId = user.Id,
                PhoneNumber = model.PhoneNumber,
                ProfilePicture = "~/wwwroot/img/customer.png",
                UserName = userName,
                VillageName = model.VillageName
            };
            return Userinfo;
        }
    }
}
