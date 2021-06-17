using System;
using System.Collections.Generic;

namespace Forum.DomainClasses.Models
{
    public class Post
    {
        public Post()
        {
            Replies = new HashSet<Reply>();
        }

        public Guid PostId { get; set; }
        public Guid ThreadId { get; set; }
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Content { get; set; }
        public bool Reported { get; set; }
        public bool Edited { get; set; }
        public string EditedBy { get; set; }
        public DateTime DatePosted { get; set; }
        public int RepliesCount { get; set; }

        public virtual Thread Thread { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
    }
}
