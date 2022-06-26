using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketPlaces.Data.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task Add(TEntity entity);
        void Dispose();
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int? id);
        Task Remove(TEntity entity);
        Task Update(TEntity entity);
    }
}