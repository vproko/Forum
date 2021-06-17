using System;
using System.Collections.Generic;

namespace Forum.Dto.Models
{
    public class PostDto
    {
        public Guid PostId { get; set; }
        public string Content { get; set; }
        public DateTime DatePosted { get; set; }
        public bool Reported { get; set; }
        public bool Edited { get; set; }
        public string EditedBy { get; set; }
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public Guid ThreadId { get; set; }
        public int RepliesCount { get; set; }

        public IEnumerable<ReplyDto> Replies { get; set; }
        public UserDto User { get; set; }
        public ThreadDto Thread { get; set; }
    }
}