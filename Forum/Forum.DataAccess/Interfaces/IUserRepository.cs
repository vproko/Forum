using Forum.DomainClasses.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.DataAccess.Interfaces
{
    public interface IUserRepository : IRepository<User> 
    {
        Task<IEnumerable<User>> GetUsersInfoAsync(int pageIndex, int pageSize);
        Task<IEnumerable<User>> GetUsersInfoBySearchAsync(string searchTerm, int pageIndex, int pageSize);
        Task<User> FindUserInfoAsync(Guid userId);
        Task<User> GetUsersMessagesAsync(string username, int pageIndex, int pageSize);
    }
}
