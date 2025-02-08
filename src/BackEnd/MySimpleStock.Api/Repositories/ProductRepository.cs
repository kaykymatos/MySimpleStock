using MySimpleStock.Api.Context;
using MySimpleStock.Api.Models.Entity;

namespace MySimpleStock.Api.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContextApi context) : base(context)
        {
        }
    }
}
