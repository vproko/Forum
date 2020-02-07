using System.Collections.Generic;

namespace Forum.DataAccess.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(string id);
        int Insert(TEntity entity);
        int Update(TEntity entity);
        int Delete(string id);
    }
}
