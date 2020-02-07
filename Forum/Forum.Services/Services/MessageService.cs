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
    public class MessageService : IMessageService
    {
        private readonly IRepository<Message> _messageRepository;
        private readonly IMapper _mapper;

        public MessageService(IRepository<Message> messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MessageViewModel>> GetAllMessagesAsync()
        {
            return await Task.Run(() => _mapper.Map<IEnumerable<MessageViewModel>>(_messageRepository.GetAll()));
        }

        public async Task<IEnumerable<MessageViewModel>> GetMessagesByUsernameAsync(string username)
        {
            try
            {
                IEnumerable<Message> messages = await Task.Run(() => _messageRepository.GetAll());
                var usersMessages = messages.Where(m => m.ReceiverUsername == username);
                return _mapper.Map<IEnumerable<MessageViewModel>>(usersMessages);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task CreateMessageAsync(MessageViewModel message)
        {
            int result = await Task.Run(() => _messageRepository.Insert(_mapper.Map<Message>(message)));

            CheckForError(result);
        }

        public async Task DeleteMessageAsync(string messageId)
        {
            Message message = await Task.Run(() => _messageRepository.GetById(messageId));

            if (message != null)
            {
                int result = await Task.Run(() => _messageRepository.Delete(messageId));
                CheckForError(result);
            }
            else
                throw new Exception("There's no message with that id");
        }

        public async Task DeleteAllUsersMessagesAsync(string userId)
        {
            IEnumerable<Message> messages = await Task.Run(() => _messageRepository.GetAll());

            foreach (Message message in messages)
            {
                if (message.ReceiverID == userId)
                    await Task.Run(() => _messageRepository.Delete(message.MessageID));
            }
        }

        private void CheckForError(int result)
        {
            if (result == -1)
                throw new Exception("Something went wrong");
        }
    }
}
