using System;

namespace Forum.DomainClasses.Models
{
    public class Reply
    {
        public Guid ReplyId { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Content { get; set; }
        public bool Reported { get; set; }
        public DateTime DateReplied { get; set; }
        public bool Edited { get; set; }
        public string EditedBy { get; set; }

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}
