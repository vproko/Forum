using System;
using System.Collections.Generic;

namespace Forum.DomainClasses.Models
{
    public class Thread
    {
        public string ThreadID { get; set; }
        public string Title { get; set; }
        public string CategoryID { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Category Category { get; set; }
        public virtual IEnumerable<Post> Posts { get; set; }
    }
}
