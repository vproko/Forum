using System;
using System.Collections.Generic;

namespace Forum.DomainClasses.Models
{
    public class Thread
    {
        public Thread()
        {
            Posts = new HashSet<Post>();
        }

        public Guid ThreadId { get; set; }
        public Guid CategoryId { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public int PostsCount { get; set; }
        public bool Locked { get; set; }
        public bool Sticky { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
