using System;
using System.ComponentModel.DataAnnotations;

namespace Forum.ViewModels.ViewModels
{
    public class ReplyViewModel
    {
        public Guid ReplyId { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public string Username { get; set; }
        [Display(Name = "YOUR REPLY:")]
        public string Content { get; set; }
        public bool Reported { get; set; }
        public DateTime DateReplied { get; set; }
        public bool Edited { get; set; }
        public string EditedBy { get; set; }

        public UserViewModel User { get; set; }
    }
}