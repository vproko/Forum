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
    public class ThreadService : IThreadService
    {
        private readonly IRepository<Thread> _threadRepository;
        private readonly IMapper _mapper;

        public ThreadService(IRepository<Thread> threadRepository, IMapper mapper)
        {
            _threadRepository = threadRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ThreadViewModel>> GetAllThreadsAsync()
        {
            return await Task.Run(() => _mapper.Map<IEnumerable<ThreadViewModel>>(_threadRepository.GetAll()));
        }

        public async Task<IEnumerable<ThreadViewModel>> GetThreadsByCategoryAsync(string categoryId)
        {
            return await Task.Run(() => _mapper.Map<IEnumerable<ThreadViewModel>>(_threadRepository.GetAll()
                .Where(t => t.CategoryID == categoryId)
                .OrderByDescending(t => t.DateCreated.Date)
                .ThenByDescending(t => t.DateCreated.TimeOfDay)));
        }

        public async Task<ThreadViewModel> GetThreadByIdAsync(string threadId)
        {
            Thread thread = await Task.Run(() => _threadRepository.GetById(threadId));

            if (thread != null)
                return _mapper.Map<ThreadViewModel>(thread);
            else
                throw new Exception("There's no thread with that id");
        }

        public async Task CreateThreadAsync(ThreadViewModel entity)
        {
            int result = await Task.Run(() => _threadRepository.Insert(_mapper.Map<Thread>(entity)));

            CheckForError(result);
        }

        public async Task UpdateThreadAsync(ThreadViewModel entity)
        {
            Thread thread = await Task.Run(() => _mapper.Map<Thread>(_threadRepository.GetById(entity.ThreadID)));

            if (thread != null)
            {
                thread.ThreadID = entity.ThreadID;
                thread.Title = entity.Title;
                thread.CategoryID = entity.CategoryID;
                thread.DateCreated = entity.DateCreated;

                int result = await Task.Run(() => _threadRepository.Update(thread));
                CheckForError(result);
            }
            else
                throw new Exception("There's no thread with that id");
        }

        public void MoveThread(string categoryId, string threadId)
        {
            Thread thread = _threadRepository.GetById(threadId);

            if (thread != null)
            {
                thread.CategoryID = categoryId;
                int result = _threadRepository.Update(thread);
                CheckForError(result);
            }
            else
                throw new Exception("There's no thread with that id");
        }

        public async Task DeleteThreadAsync(string threadId)
        {
            Thread thread = await Task.Run(() =>_threadRepository.GetById(threadId));

            if (thread != null)
            {
                int result = await Task.Run(() => _threadRepository.Delete(threadId));
                CheckForError(result);
            }
            else
                throw new Exception("There's no thread with that id");
        }

        private void CheckForError(int result)
        {
            if (result == -1)
                throw new Exception("Something went wrong");
        }
    }
}
