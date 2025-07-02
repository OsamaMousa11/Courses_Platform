using CoursePlatform.Core.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePlatform.Core.DTO
{
    public  class RegisterDto
    {
        [Required(ErrorMessage = "{0} Can't be Blank")]
        [Display(Name = "User Name")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "{0} Can't be Blank")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [Remote(action: "IsEmailAvailable", controller: "Account", ErrorMessage = "Email already in use")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "{0} Can't be Blank")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "{0} Can't be Blank")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "{0} Can't be Blank")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessage = "User Type is required")]
        public UserTypeOptions UserType { get; set; } = UserTypeOptions.User;
    }
}
