using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Forum.DomainClasses.Models
{
    public class User : IdentityUser<Guid>
    {
        public User()
        {
            Posts = new HashSet<Post>();
            Replies = new HashSet<Reply>();
            Messages = new HashSet<Message>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsItAdministrator { get; set; }
        public bool Online { get; set; }
        public bool Suspended { get; set; }
        public string Avatar { get; set; }
        public DateTime Joined { get; set; }
        public int PostsCount { get; set; }
        public int RepliesCount { get; set; }
        public int MessagesCount { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}