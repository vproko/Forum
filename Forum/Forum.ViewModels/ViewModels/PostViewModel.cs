using System;

namespace Forum.ViewModels.ViewModels
{
    public class PostViewModel
    {
        public string PostID { get; set; }
        public string UserID { get; set; }
        public string ThreadID { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Reported { get; set; } = false;

        public UserViewModel User { get; set; }
        public ThreadViewModel Thread { get; set; }
    }
}
