using System;
using System.Collections.Generic;

namespace Forum.Dto.Models
{
    public class ThreadDto
    {
        public Guid ThreadId { get; set; }
        public DateTime DateCreated { get; set; }
        public string Title { get; set; }
        public Guid CategoryId { get; set; }
        public int PostsCount { get; set; }
        public bool Locked { get; set; }
        public bool Sticky { get; set; }

        public IEnumerable<PostDto> Posts { get; set; }
        public CategoryDto Category { get; set; }
    }
}