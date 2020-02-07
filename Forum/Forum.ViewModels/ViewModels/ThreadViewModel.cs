using System;
using System.Collections.Generic;

namespace Forum.ViewModels.ViewModels
{
    public class ThreadViewModel
    {
        public string ThreadID { get; set; }
        public string Title { get; set; }
        public string CategoryID { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual CategoryViewModel Category { get; set; }
        public virtual IEnumerable<PostViewModel> Posts { get; set; }
    }
}
