using Microsoft.EntityFrameworkCore;
using MyGoodStock.Api.Context;
using MyGoodStock.Api.Models.Entity;

namespace MyGoodStock.Api.Repositories
{
    public class BaseRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContextApi _context;
        public BaseRepository(ApplicationDbContextApi context)
        {
            _context = context;
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            entity.CreationDate = DateTime.Now;
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            //entity.Id = id;
            return entity;
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAll(Guid userId) => await _context.Set<T>().Where(x => x.UserId == userId).ToListAsync();

        public virtual async Task<T> GetById(Guid id, Guid userId) => await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);

        public virtual async Task<T> UpdateAsync(T entity)
        {
            var existingEntity = await _context.Set<T>().FindAsync(entity.Id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).State = EntityState.Detached; // Remove a instância rastreada
            }
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
