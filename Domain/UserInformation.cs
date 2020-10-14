using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Domain
{
    public class UserInformation : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string VillageName { get; set; }
        public string FatherName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal Amount { get; set; }
        public string ProfilePicture { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }
    }
}
