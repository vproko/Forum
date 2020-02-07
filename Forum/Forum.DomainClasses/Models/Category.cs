using System;
using System.Collections.Generic;

namespace Forum.DomainClasses.Models
{
    public class Category
    {
        public string CategoryID { get; set; }
        public string Title { get; set; }

        public virtual IEnumerable<Thread> Threads { get; set; }
    }
}
