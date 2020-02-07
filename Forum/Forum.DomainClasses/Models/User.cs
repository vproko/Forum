using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Forum.DomainClasses.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime Joined { get; set; }
        public bool Online { get; set; } = false;
        public bool Suspended { get; set; } = false;
        public bool Administrator { get; set; } = false;
        public string Avatar { get; set; }

        public virtual IEnumerable<Post> Posts { get; set; }
        public virtual IEnumerable<Message> Messages { get; set; }
    }
}
