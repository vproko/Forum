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
    public class ReplyService : BaseService, IReplyService
    {
        public ReplyService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public async Task<IEnumerable<ReplyDto>> GetReportedRepliesPerPageAsync(int pageIndex, int pageSize, CancellationToken ct)
        {
            return _mapper.Map<IEnumerable<ReplyDto>>(await _unitOfWork.Replies.GetReportedRepliesAsync(pageIndex, pageSize, ct));
        }

        public async Task<int> GetReportedRepliesCountAsync()
        {
            return await _unitOfWork.Replies.GetReportedRepliesCountAsync();
        }

        public async Task DeleteUsersRepliesAsync(Guid userId)
        {
            IEnumerable<Reply> replies = await _unitOfWork.Replies.GetUsersRepliesAsync(userId);
            _unitOfWork.Replies.RemoveRange(replies);
            await _unitOfWork.CompleteAsync();
        }

        public async Task CreateAsync(ReplyDto reply)
        {
            _unitOfWork.Replies.Add(_mapper.Map<Reply>(reply));
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(ReplyDto reply)
        {
            Reply match = await _unitOfWork.Replies.FindAsync(reply.ReplyId);
            match.Content = reply.Content ?? match.Content;
            match.Edited = true;
            match.EditedBy = reply.EditedBy;
            match.DateReplied = DateTime.UtcNow;
            await _unitOfWork.CompleteAsync();
        }

        public async Task ReportAsync(Guid replyId)
        {
            Reply match = await _unitOfWork.Replies.FindAsync(replyId);
            match.Reported = true;
            await _unitOfWork.CompleteAsync();
        }

        public async Task UnReportAsync(Guid replyId)
        {
            Reply match = await _unitOfWork.Replies.FindAsync(replyId);
            match.Reported = false;
            await _unitOfWork.CompleteAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            _unitOfWork.Replies.Remove(await _unitOfWork.Replies.FindAsync(id));
            await _unitOfWork.CompleteAsync();
        }
    }
}
