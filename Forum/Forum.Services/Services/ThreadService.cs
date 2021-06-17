using AutoMapper;
using Forum.DataAccess.Interfaces;
using Forum.DomainClasses.Models;
using Forum.Dto.Models;
using Forum.Services.Interfaces;
using Forum.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Services.Services
{
    public class ThreadService : BaseService, IThreadService
    {
        public ThreadService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public async Task CreateAsync(ThreadViewModel newThread)
        {
            _unitOfWork.Threads.Add(_mapper.Map<Thread>(_mapper.Map<ThreadDto>(newThread)));
            await _unitOfWork.CompleteAsync();
        }

        public async Task<ThreadDto> FindThreadWithRelatedDataAsync(Guid id, int pageIndex, int pageSize)
        {
            return _mapper.Map<ThreadDto>(await _unitOfWork.Threads.GetThreadByIdAsync(id, pageIndex, pageSize));
        }

        public async Task RemoveAsync(Guid id)
        {
            _unitOfWork.Threads.Remove(await _unitOfWork.Threads.FindAsync(id));
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(ThreadDto thread)
        {
            Thread match = await _unitOfWork.Threads.FindAsync(thread.ThreadId);
            match.Title = thread.Title ?? match.Title;
            await _unitOfWork.CompleteAsync();
        }

        public async Task MoveThreadAsync(Guid threadId, Guid categoryId)
        {
            Thread match = await _unitOfWork.Threads.FindAsync(threadId);
            match.CategoryId = categoryId;
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<ThreadDto>> GetThreadsBySearchAsync(string term)
        {
            return _mapper.Map<IEnumerable<ThreadDto>>(await _unitOfWork.Threads.SearchThreadsAsync(term));
        }

        public async Task StickThreadAsync(Guid threadId)
        {
            Thread match = await _unitOfWork.Threads.FindAsync(threadId);
            match.Sticky = true;
            await _unitOfWork.CompleteAsync();
        }

        public async Task UnStickThreadAsync(Guid threadId)
        {
            Thread match = await _unitOfWork.Threads.FindAsync(threadId);
            match.Sticky = false;
            await _unitOfWork.CompleteAsync();
        }

        public async Task LockThreadAsync(Guid threadId)
        {
            Thread match = await _unitOfWork.Threads.FindAsync(threadId);
            match.Locked = true;
            await _unitOfWork.CompleteAsync();
        }

        public async Task UnlockThreadAsync(Guid threadId)
        {
            Thread match = await _unitOfWork.Threads.FindAsync(threadId);
            match.Locked = false;
            await _unitOfWork.CompleteAsync();
        }
    }
}