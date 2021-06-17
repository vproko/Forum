using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.DataAccess.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> FindAsync(Guid id);
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
