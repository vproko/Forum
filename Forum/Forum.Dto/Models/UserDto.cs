using System;
using System.Collections.Generic;

namespace Forum.Dto.Models
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsItAdministrator { get; set; }
        public bool Online { get; set; }
        public bool Suspended { get; set; }
        public string Avatar { get; set; }
        public DateTime Joined { get; set; }
        public int PostsCount { get; set; }
        public int RepliesCount { get; set; }
        public int MessagesCount { get; set; }

        public IEnumerable<PostDto> Posts { get; set; }
        public IEnumerable<ReplyDto> Replies { get; set; }
        public IEnumerable<MessageDto> Messages { get; set; }
    }
}
