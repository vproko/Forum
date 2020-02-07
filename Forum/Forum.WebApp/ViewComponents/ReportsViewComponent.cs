using Forum.Services.Interfaces;
using Forum.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.WebApp.ViewComponents
{
    public class ReportsViewComponent
    {
        private readonly IPostService _postService;

        public ReportsViewComponent(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<string> InvokeAsync()
        {
            IEnumerable<PostViewModel> posts = await _postService.GetAllPostAsync();
            int alerts = posts.Where(p => p.Reported == true).Count();

            return $"{alerts}";
        }
    }
}
