using AutoMapper;
using Forum.DataAccess.Interfaces;
using Forum.DomainClasses.Models;
using Forum.Services.Interfaces;
using Forum.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Services
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post> _postRepository;
        private readonly IMapper _mapper;

        public PostService(IRepository<Post> postrepository, IMapper mapper)
        {
            _postRepository = postrepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PostViewModel>> GetAllPostAsync()
        {
            return await Task.Run(() => _mapper.Map<IEnumerable<PostViewModel>>(_postRepository.GetAll()));
        }

        public async Task<IEnumerable<PostViewModel>> GetReportedPostsByUserIdAsync(string userId)
        {
            return await Task.Run(() => _mapper.Map<IEnumerable<PostViewModel>>(_postRepository.GetAll().Where(p => p.UserID == userId && p.Reported == true)));
        }

        public async Task<IEnumerable<PostViewModel>> GetAllReportedPostsAsync()
        {
            return await Task.Run(() => _mapper.Map<IEnumerable<PostViewModel>>(_postRepository.GetAll().Where(p => p.Reported == true).OrderBy(p => p.UserID)));
        }

        public async Task<IEnumerable<PostViewModel>> GetPostsByThreadAsync(string threadId)
        {
            try
            {
                return await Task.Run(() => _mapper.Map<IEnumerable<PostViewModel>>(_postRepository.GetAll()
                        .Where(p => p.ThreadID == threadId)
                        .OrderBy(p => p.DateCreated)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<PostViewModel>> GetAllRecentPostsAsync()
        {
            try
            {
                return await Task.Run(() => _mapper.Map<IEnumerable<PostViewModel>>(_postRepository.GetAll()
                        .OrderByDescending(p => p.DateCreated.Date)
                        .ThenByDescending(p => p.DateCreated.TimeOfDay)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<PostViewModel>> SearchPostsAsync(string search)
        {
            try
            {
                return await Task.Run(() => _mapper.Map<IEnumerable<PostViewModel>>(_postRepository.GetAll()
                        .Where(p => p.Content.Contains(search, StringComparison.OrdinalIgnoreCase))
                        .OrderByDescending(p => p.DateCreated.Date)
                        .ThenByDescending(p => p.DateCreated.TimeOfDay)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PostViewModel> GetPostByIdAsync(string postId)
        {
            Post post = await Task.Run(() => _postRepository.GetById(postId));

            if (post != null)
                return _mapper.Map<PostViewModel>(post);
            else
                throw new Exception("there's no post with that id");
        }

        public async Task CreatePostAsync(PostViewModel post)
        {
            int result = await Task.Run(() => _postRepository.Insert(_mapper.Map<Post>(post)));

            CheckForError(result);
        }

        public async Task CreatePostReplyAsync(string originalPoster, string originalPost, PostViewModel reply)
        {
            string splitter = "e3f79af2";

            reply.Content = "Posted by " + originalPoster + ": " + splitter + " " +
                                           originalPost.Replace("e3f79af2", "") + " " + splitter + " " +
                                           reply.Content;

            int result = await Task.Run(() => _postRepository.Insert(_mapper.Map<Post>(reply)));

            CheckForError(result);
        }

        public async Task ChangePostAsync(PostViewModel entity)
        {
            Post post = await Task.Run(() => _mapper.Map<Post>(_postRepository.GetById(entity.PostID)));

            if (post != null)
            {
                post.PostID = entity.PostID;
                post.UserID = entity.UserID;
                post.ThreadID = entity.ThreadID;
                post.Content = entity.Content;
                post.DateCreated = entity.DateCreated;
                post.Reported = entity.Reported;

                int result = await Task.Run(() => _postRepository.Update(post));
                CheckForError(result);
            }
            else
                throw new Exception("There's no post with that ID");
        }

        public async Task ReportUnreportPostAsync(string postId)
        {
            Post post = await Task.Run(() => _postRepository.GetById(postId));
            post.Reported = !post.Reported;

            await Task.Run(() => _postRepository.Update(post));
        }

        public async Task UnreportAllPostsByUserIdAsync(string userId)
        {
            IEnumerable<PostViewModel> usersPosts = await GetReportedPostsByUserIdAsync(userId);

            foreach (PostViewModel post in usersPosts)
            {
                await ReportUnreportPostAsync(post.PostID);
            }
        }

        public async Task MovePostAsync(string postId, string threadId)
        {
            Post post = await Task.Run(() => _postRepository.GetById(postId));

            if (post != null)
            {
                post.ThreadID = threadId;
                int result = await Task.Run(() => _postRepository.Update(post));
                CheckForError(result);
            }
            else
                throw new Exception("There's no post with that id");
        }

        public async Task DeletePostAsync(string postId)
        {
            Post post = await Task.Run(() =>_postRepository.GetById(postId));

            if (post != null)
            {
                int result = await Task.Run(() => _postRepository.Delete(postId));
                CheckForError(result);
            }
            else
                throw new Exception("There's no post with that id");
        }

        public async Task DeleteReportedPostsByUserIdAsync(string userId)
        {
            IEnumerable<PostViewModel> reportedPosts = await GetReportedPostsByUserIdAsync(userId);

            foreach (PostViewModel post in reportedPosts)
            {
                await DeletePostAsync(post.PostID);
            }
        }

        private void CheckForError(int result)
        {
            if (result == -1)
                throw new Exception("Something went wrong");
        }
    }
}
