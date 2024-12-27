using MyGoodStock.Api.Models;

namespace MyGoodStock.Api.Services
{
    public interface IBaseService<T> where T : class
    {

        Task<ResponseApiModel> CreateAsync(T model);
        Task<ResponseApiModel> UpdateAsync(T model);
        Task<ResponseApiModel> DeleteAsync(Guid id, Guid userId);
        Task<IEnumerable<T>> GetAllAsync(Guid iuserId);
        Task<T> GetOneAsync(Guid id, Guid iuserId);
    }
}
