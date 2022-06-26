using MarketPlaces.Data.Interfaces;
using MarketPlaces.Entity.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketPlaces.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly MarketPlacesContext _context;

        public BaseRepository(MarketPlacesContext context)
        {
            _context = context;
        }

        public virtual async Task Add(TEntity obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }     
       
        public virtual async Task<TEntity> GetById(int? id)
        {
           return await _context.Set<TEntity>().FindAsync(id);
        }
         
        public virtual async Task Remove(TEntity obj)
        {
            _context.Set<TEntity>().Remove(obj);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {  
            _context.Dispose();
        }
          
    }
}
