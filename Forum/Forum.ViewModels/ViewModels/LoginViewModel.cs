using System.ComponentModel.DataAnnotations;

namespace Forum.ViewModels.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "This field must be filled")]
        [Display(Name = "USERNAME")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "This field must be filled")]
        [Display(Name = "PASSWORD")]
        public string Password { get; set; }
    }
}
