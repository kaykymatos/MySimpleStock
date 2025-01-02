using MySimpleStock.Api.Models.Entity;
using MySimpleStock.Api.Repositories;

namespace MySimpleStock.Api.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
    }
}
