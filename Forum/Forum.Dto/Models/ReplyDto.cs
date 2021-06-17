using System;

namespace Forum.Dto.Models
{
    public class ReplyDto
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

        public UserDto User { get; set; }
    }
}