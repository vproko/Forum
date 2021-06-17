using AutoMapper;
using Forum.DataAccess.Interfaces;
using Forum.DomainClasses.Models;
using Forum.Dto.Models;
using Forum.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Services.Services
{
    public class PostService : BaseService, IPostService
    {
        public PostService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public async Task CreateAsync(PostDto newPost, string username)
        {
            _unitOfWork.Posts.Add(_mapper.Map<Post>(newPost));
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<PostDto>> GetPostsByUsersIdAsync(Guid userId, int pageIndex, int pageSize, CancellationToken ct)
        {
            return _mapper.Map<IEnumerable<PostDto>>(await _unitOfWork.Posts.GetUsersPostsAsync(userId, pageIndex, pageSize, ct));
        }

        public async Task<IEnumerable<PostDto>> GetReportedPostsPerPageAsync(int pageIndex, int pageSize, CancellationToken ct)
        {
            return _mapper.Map<IEnumerable<PostDto>>(await _unitOfWork.Posts.GetReportedPostsAsync(pageIndex, pageSize, ct));
        }

        public async Task<int> GetReportedPostsCountAsync()
        {
            return await _unitOfWork.Posts.GetReportedPostsCountAsync();
        }

        public async Task UpdateAsync(PostDto post, string username)
        {
            Post match = await _unitOfWork.Posts.FindAsync(post.PostId);
            match.Content = post.Content ?? match.Content;
            match.Edited = true;
            match.EditedBy = post.EditedBy == "Admin" ? "Admin" : username;
            await _unitOfWork.CompleteAsync();
        }

        public async Task ReportAsync(Guid id)
        {
            Post match = await _unitOfWork.Posts.FindAsync(id);
            match.Reported = true;
            await _unitOfWork.CompleteAsync();
        }

        public async Task UnReportAsync(Guid id)
        {
            Post match = await _unitOfWork.Posts.FindAsync(id);
            match.Reported = false;
            await _unitOfWork.CompleteAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            _unitOfWork.Posts.Remove(await _unitOfWork.Posts.FindAsync(id));
            await _unitOfWork.CompleteAsync();
        }

        public async Task MovePostAsync(Guid postId, Guid threadId)
        {
            Post match = await _unitOfWork.Posts.FindAsync(postId);
            match.DatePosted = DateTime.UtcNow;
            match.ThreadId = threadId;
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<PostDto>> GetRecentPostsPerPageAsync(int pageIndex, int pageSize, CancellationToken ct)
        {
            return _mapper.Map<IEnumerable<PostDto>>(await _unitOfWork.Posts.GetRecentPostsAsync(pageIndex, pageSize, ct));
        }

        public async Task<IEnumerable<PostDto>> FindPostsAsync(string term, int pageIndex, int pageSize, CancellationToken ct)
        {
            return _mapper.Map<IEnumerable<PostDto>>(await _unitOfWork.Posts.SearchPostsAsync(term, pageIndex, pageSize, ct));
        }
    }
}