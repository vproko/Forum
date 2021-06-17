using System.ComponentModel.DataAnnotations;

namespace Forum.ViewModels.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required]
        [Display(Name = "Old password")]
        public string OldPassword { get; set; }
        [Required]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }
        [Required]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "It doesn't match with \"New Password\" field")]
        public string ConfrimNewPassword { get; set; }
    }
}
