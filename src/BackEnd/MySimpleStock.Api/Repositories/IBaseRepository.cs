using MySimpleStock.Api.Models.Entity;

namespace MySimpleStock.Api.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetById(Guid id, Guid iuserId);
        Task<IEnumerable<T>> GetAll(Guid iuserId);
    }
}
