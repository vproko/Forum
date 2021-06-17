using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Forum.ViewModels.ViewModels
{
    public class CategoryViewModel
    {
        public Guid CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        public int ThreadsCount { get; set; }

        public IEnumerable<ThreadViewModel> Threads { get; set; }
    }
}
