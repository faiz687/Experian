using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketPlaces.Data.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task Add(TEntity obj);
        void Dispose();
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int? id);
        Task Remove(TEntity obj);
        Task Update(TEntity obj);
    }
}