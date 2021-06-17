using Forum.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Forum.WebApp.ViewComponents
{
    public class ReportsCountViewComponent : ViewComponent
    {
        private readonly IPostService _postService;
        private readonly IReplyService _replyService;

        public ReportsCountViewComponent(IPostService postService, IReplyService replyService)
        {
            _postService = postService;
            _replyService = replyService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int postsCount = await _postService.GetReportedPostsCountAsync();
            int repliesCount = await _replyService.GetReportedRepliesCountAsync();
            int totalReports = postsCount + repliesCount;

            return Content(totalReports.ToString());
        }
    }
}