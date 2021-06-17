using Forum.ViewModels.CustomValidations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Forum.ViewModels.ViewModels
{
    public class UpdateInfoViewModel
    {
        [Display(Name = "Change first name")]
        public string FirstName { get; set; }
        [Display(Name = "Change last name")]
        public string LastName { get; set; }
        [Display(Name = "Change email")]
        public string Email { get; set; }
        public string Avatar { get; set; }

        [Display(Name = "Choose profile image(size limit 2MB)")]
        [ValidImageFile(ErrorMessage = "You can upload only image files")]
        public IFormFile UserImage { get; set; }
    }
}