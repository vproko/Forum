using System;
using System.Collections.Generic;

namespace Forum.Dto.Models
{
    public class CategoryDto
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public int ThreadsCount { get; set; }

        public IEnumerable<ThreadDto> Threads { get; set; }
    }
}
