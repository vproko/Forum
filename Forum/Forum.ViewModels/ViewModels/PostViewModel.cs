using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Forum.ViewModels.ViewModels
{
    public class PostViewModel
    {
        public Guid PostId { get; set; }
        [Display(Name = "YOUR POST:")]
        public string Content { get; set; }
        public DateTime DatePosted { get; set; }
        public bool Reported { get; set; }
        public bool Edited { get; set; }
        public string EditedBy { get; set; }
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public Guid ThreadId { get; set; }
        public int RepliesCount { get; set; }
        public IEnumerable<ReplyViewModel> Replies { get; set; }

        public UserViewModel User { get; set; }
        public ThreadViewModel Thread { get; set; }
    }
}