namespace Forum.ViewModels.ViewModels
{
    public class UpdateUserViewModel
    {
        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
        public string Email { get; set; }
    }
}
