using System;
using System.Collections.Generic;

namespace Forum.ViewModels.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public DateTime Joined { get; set; }
        public bool Online { get; set; }
        public bool Suspended { get; set; }
        public bool Administrator { get; set; }
        public string Avatar { get; set; }
        public IEnumerable<PostViewModel> Posts { get; set; }
        public IEnumerable<MessageViewModel> Messages { get; set; }
    }
}
