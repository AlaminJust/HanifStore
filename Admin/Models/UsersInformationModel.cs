using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Admin.Models
{
    public class UsersInformationModel  
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
        public string UserId { get; set; }
    }
}
