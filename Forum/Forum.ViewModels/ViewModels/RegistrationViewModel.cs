using Forum.ViewModels.CustomValidations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Forum.ViewModels.ViewModels
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "You must enter your name")]
        [Display(Name = "FIRST NAME")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You must enter your last name")]
        [Display(Name = "LAST NAME")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You must enter username")]
        [Display(Name = "USERNAME")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "EMAIL")]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Must be at least 8 characters long.")]
        [Display(Name = "PASSWORD (min length 8, format: Aa-Zz, 0-9, !@#$%^&*)")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "CONFIRM PASSWORD")]
        [Compare("Password", ErrorMessage = "Your password doesn't match.")]
        public string ConfirmPassword { get; set; }

        public string Avatar { get; set; } = "not set";
        public string Role { get; set; }

        [Display(Name = "PROFILE IMAGE (size limit 2MB)")]
        [ValidImageFile(ErrorMessage = "You can upload only image files")]
        public IFormFile UserImage { get; set; }
    }
}