using Forum.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Services.Interfaces
{
    public interface IThreadService
    {
        Task<IEnumerable<ThreadViewModel>> GetAllThreadsAsync();
        Task<IEnumerable<ThreadViewModel>> GetThreadsByCategoryAsync(string categoryId);
        Task<ThreadViewModel> GetThreadByIdAsync(string threadId);
        Task CreateThreadAsync(ThreadViewModel entity);
        Task UpdateThreadAsync(ThreadViewModel entity);
        void MoveThread(string categoryId, string threadId);
        Task DeleteThreadAsync(string threadId);
    }
}
