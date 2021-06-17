using System.Collections.Generic;

namespace Forum.ViewModels.ViewModels
{
    public class ReportsViewModel
    {
        public IEnumerable<PostViewModel> ReportedPosts { get; set; }
        public IEnumerable<ReplyViewModel> ReportedReplies { get; set; }
    }
}
