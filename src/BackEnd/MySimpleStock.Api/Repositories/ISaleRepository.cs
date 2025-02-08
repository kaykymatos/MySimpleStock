using MySimpleStock.Api.Models.Entity;

namespace MySimpleStock.Api.Repositories
{
    public interface ISaleRepository : IBaseRepository<Sale>
    {
        Task<IEnumerable<Sale>> GetAllSales(Guid userId);
    }
}
