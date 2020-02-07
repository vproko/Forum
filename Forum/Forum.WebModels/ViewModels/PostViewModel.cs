using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.WebModels.ViewModels
{
    public class PostViewModel
    {
        public string PostID { get; set; }
        public string UserID { get; set; }
        public string ThreadID { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }

        public UserViewModel User { get; set; }
        public ThreadViewModel Thread { get; set; }
        public AlertViewModel Alert { get; set; }
    }
}
