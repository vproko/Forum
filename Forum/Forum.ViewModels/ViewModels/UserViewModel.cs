using System;
using System.Collections.Generic;

namespace Forum.ViewModels.ViewModels
{
    public class UserViewModel
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool Online { get; set; }
        public bool Suspended { get; set; }
        public bool IsItAdministrator { get; set; }
        public string Avatar { get; set; }
        public DateTime Joined { get; set; }
        public int PostsCount { get; set; }
        public int RepliesCount { get; set; }
        public int MessagesCount { get; set; }

        public IEnumerable<PostViewModel> Posts { get; set; }
        public IEnumerable<ReplyViewModel> Replies { get; set; }
        public IEnumerable<MessageViewModel> Messages { get; set; }
    }
}
