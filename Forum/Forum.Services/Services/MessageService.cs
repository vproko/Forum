using AutoMapper;
using Forum.DataAccess.Interfaces;
using Forum.DomainClasses.Models;
using Forum.Dto.Models;
using Forum.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Services.Services
{
    public class MessageService : BaseService, IMessageService
    {
        private readonly UserManager<User> _userManager;
        public MessageService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager) : base(unitOfWork, mapper)
        {
            _userManager = userManager;
        }

        public async Task<IEnumerable<MessageDto>> GetUsersMessagesPerPageAsync(string username, int pageIndex, int pageSize)
        {
            User user = await _userManager.FindByNameAsync(username);
            return _mapper.Map<IEnumerable<MessageDto>>(await _unitOfWork.Messages.GetMessagesAsync(user.Id, pageIndex, pageSize));
        }

        public async Task<int> GetMessagesCountAsync(string username)
        {
            User user = await _userManager.FindByNameAsync(username);
            return await _unitOfWork.Messages.GetMessagesCountAsync(user.Id);
        }

        public async Task CreateAsync(MessageDto message)
        {
            _unitOfWork.Messages.Add(_mapper.Map<Message>(message));
            await _unitOfWork.CompleteAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            _unitOfWork.Messages.Remove(await _unitOfWork.Messages.FindAsync(id));
            await _unitOfWork.CompleteAsync();
        }
    }
}