using System;
using System.Collections.Generic;

namespace Forum.DomainClasses.Models
{
    public class Category
    {
        public Category()
        {
            Threads = new HashSet<Thread>();
        }

        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public int ThreadsCount { get; set; }

        public virtual ICollection<Thread> Threads { get; set; }
    }
}