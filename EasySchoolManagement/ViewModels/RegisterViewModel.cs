using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using EasySchoolManagement.Utilities;

namespace EasySchoolManagement.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller: "Account")]
        [ValidateEmailDomain(allowedDomain: "shadow.com", ErrorMessage = "Email domain must be shadow.com")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password & Confirm Password do not match!")]
        public string ConfirmPassword { get; set; }

        public string City { get; set; }

    }
}
