using HanifStore.Admin.Models;
using HanifStore.Client.Models;
using HanifStore.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Services
{
    public interface IUserService
    {
        public Task<IdentityResult> userRegistration(Registration model);
        public Task<Boolean> userLogin(Login model);
        public Task<Boolean> userLogout(); 
        public bool checkDuplicateUser(Registration model);
        public IdentityUser getIdentityUserByUserNameOrPhoneNumber(string userName = null , string phoneNumber = null);
        public UserInformation InsertUserInformation(UserInformation userInformation);
        public IList<UsersInformation> getUsersInformation(int page = 1, int pageSize = int.MaxValue);
    }
}
