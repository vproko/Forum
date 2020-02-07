using Forum.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Services.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<PostViewModel>> GetAllPostAsync();
        Task<IEnumerable<PostViewModel>> GetReportedPostsByUserIdAsync(string userId);
        Task<IEnumerable<PostViewModel>> GetAllReportedPostsAsync();
        Task<IEnumerable<PostViewModel>> GetPostsByThreadAsync(string threadId);
        Task<IEnumerable<PostViewModel>> GetAllRecentPostsAsync();
        Task<IEnumerable<PostViewModel>> SearchPostsAsync(string search);
        Task<PostViewModel> GetPostByIdAsync(string postId);
        Task CreatePostAsync(PostViewModel post);
        Task CreatePostReplyAsync(string originalPoster, string originalPost, PostViewModel reply);
        Task ChangePostAsync(PostViewModel post);
        Task ReportUnreportPostAsync(string postId);
        Task UnreportAllPostsByUserIdAsync(string userId);
        Task MovePostAsync(string postId, string threadId);
        Task DeletePostAsync(string postId);
        Task DeleteReportedPostsByUserIdAsync(string userId);
    }
}
