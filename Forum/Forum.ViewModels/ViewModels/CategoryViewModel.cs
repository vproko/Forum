using System.Collections.Generic;

namespace Forum.ViewModels.ViewModels
{
    public class CategoryViewModel
    {
        public string CategoryID { get; set; }
        public string Title { get; set; }
        public virtual IEnumerable<ThreadViewModel> Threads { get; set; }
    }
}
