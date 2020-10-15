using HanifStore.Admin.Models;
using HanifStore.Client.Models;
using HanifStore.Data;
using HanifStore.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly AppDbContext _appDbContext;

        public UserService
            (
                UserManager<IdentityUser> userManager,
                SignInManager<IdentityUser> signInManager,
                AppDbContext appDbContext
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appDbContext = appDbContext;
        }
        #region Utilities
        public bool checkDuplicateUser(Registration model)
        {
            return _userManager.Users.Where(x => x.UserName == model.UserName.Trim().ToLower() || x.PhoneNumber == model.PhoneNumber.Trim()).Any();
        }
        private void save()
        {
            _appDbContext.SaveChanges();
        }
        #endregion
        public async Task<bool> userLogin(Login model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName.Trim().ToLower());
            if (user == null) return false;
            var result = await _signInManager.PasswordSignInAsync(model.UserName.Trim().ToLower(), model.Password.Trim(), model.RememberMe, false);
            if (result.Succeeded)
                return true;
            return false;
        }

        public async Task<bool> userLogout()
        {
            await _signInManager.SignOutAsync();
            return true;
        }

        public async Task<IdentityResult> userRegistration(Registration model)
        {
            var user = new IdentityUser { UserName = model.UserName.Trim().ToLower(), PhoneNumber = model.PhoneNumber.Trim(), Email = model.Email.Trim(), PasswordHash = model.Password.Trim() };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: true);
            }
            return result;
        }


        public IdentityUser getIdentityUserByUserNameOrPhoneNumber(string userName = null, string phoneNumber = null)
        {
            if(userName == null && phoneNumber == null)
            {
                throw new NullReferenceException(nameof(userName));
            }
            if(userName!=null)
                return _userManager.Users.Where(x => x.UserName == userName.ToLower().Trim()).FirstOrDefault();
            else return _userManager.Users.Where(x => x.PhoneNumber == phoneNumber.ToLower().Trim()).FirstOrDefault();
        }

        public UserInformation InsertUserInformation(UserInformation userInformation)
        {
            if(userInformation == null)
            {
                throw new NullReferenceException(nameof(userInformation));
            }
            _appDbContext.UserInformation.Add(userInformation);
            save();
            return userInformation;
        }

        public IList<UsersInformation> getUsersInformation(int page = 1, int pageSize = int.MaxValue)
        {
            var usersinfo = (from u in _userManager.Users
                             join uf in _appDbContext.UserInformation on u.Id equals uf.UserId
                             select new UsersInformation
                             {
                                 UserName = u.UserName,
                                 UserId = u.Id,
                                 Amount = uf.Amount,
                                 FatherName = uf.FatherName,
                                 PhoneNumber = uf.PhoneNumber,
                                 ProfilePicture = uf.ProfilePicture,
                                 FirstName = uf.FirstName,
                                 LastName = uf.LastName,
                                 VillageName = uf.VillageName,
                                 Email = uf.Email,
                                 Password = uf.Password,
                                 ConfirmPassword = uf.ConfirmPassword
                             }).Skip((page-1)*pageSize).Take(pageSize).ToList();
            return usersinfo;
        }
    }
}
