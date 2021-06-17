using Forum.Dto.Models;
using Forum.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Services.Interfaces
{
    public interface IThreadService
    {
        Task<ThreadDto> FindThreadWithRelatedDataAsync(Guid id, int pageIndex, int pageSize);
        Task CreateAsync(ThreadViewModel thread);
        Task UpdateAsync(ThreadDto thread);
        Task RemoveAsync(Guid id);
        Task<IEnumerable<ThreadDto>> GetThreadsBySearchAsync(string term);
        Task MoveThreadAsync(Guid threadId, Guid categoryId);
        Task StickThreadAsync(Guid threadId);
        Task UnStickThreadAsync(Guid threadId);
        Task LockThreadAsync(Guid threadId);
        Task UnlockThreadAsync(Guid threadId);
    }
}
