using MySimpleStock.Api.Models;
using MySimpleStock.Api.Models.ViewModel;

namespace MySimpleStock.Api.Services
{
    public interface IBaseService<T> where T : BaseViewModel
    {

        Task<ResponseApiModel<T>> CreateAsync(T model);
        Task<ResponseApiModel<T>> UpdateAsync(T model);
        Task<ResponseApiModel<T>> DeleteAsync(Guid id, Guid userId);
        Task<IEnumerable<T>> GetAllAsync(Guid iuserId);
        Task<T> GetOneAsync(Guid id, Guid iuserId);
    }
}
