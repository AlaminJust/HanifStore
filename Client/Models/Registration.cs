using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Client.Models
{
    public class Registration
    {
        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First name *")]
        public string FirstName { get; set; }
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "User name *")]
        [Required(ErrorMessage = "User name is required.")]
        public string UserName { get; set; }
        [Display(Name = "Password *")]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        [Display(Name = "Confirm password *")]
        [Required(ErrorMessage = "Confirm password is required.")]
        [Compare(nameof(Password), ErrorMessage = "Password and confirm password is not match.")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Village name *")]
        [Required(ErrorMessage = "Village name is required.")]
        public string VillageName { get; set; }
        [Display(Name = "Father name *")]
        public string FatherName { get; set; }
        [Display(Name = "Phone number *")]
        [Required(ErrorMessage = "Phone number is required.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } 
    }
}
