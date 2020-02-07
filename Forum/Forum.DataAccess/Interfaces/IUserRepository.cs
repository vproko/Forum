using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Forum.DataAccess.Interfaces
{
    public interface IUserRepository<TUser> where TUser : IdentityUser
    {
        IEnumerable<TUser> GetAll();
        TUser GetById(string id);
        TUser GetByUsername(string username);
        int Insert(TUser entity);
        int Update(TUser entity);
        int Delete(string id);
    }
}
