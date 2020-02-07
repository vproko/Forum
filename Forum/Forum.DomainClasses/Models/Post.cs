using System;

namespace Forum.DomainClasses.Models
{
    public class Post
    {
        public string PostID { get; set; }
        public string UserID { get; set; }
        public string ThreadID { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Reported { get; set; } = false;

        public virtual User User { get; set; }
        public virtual Thread Thread { get; set; }
    }
}
