using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Forum.ViewModels.ViewModels
{
    public class ThreadViewModel
    {
        public Guid ThreadId { get; set; }
        public DateTime DateCreated { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Your thread title must be long at least 3 characters")]
        public string Title { get; set; }
        public Guid CategoryId { get; set; }
        public int PostsCount { get; set; }
        public bool Locked { get; set; }
        public bool Sticky { get; set; }

        public IEnumerable<PostViewModel> Posts { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}
