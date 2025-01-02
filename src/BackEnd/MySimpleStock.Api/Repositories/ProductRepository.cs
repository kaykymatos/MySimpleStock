using MySimpleStock.Api.Context;
using MySimpleStock.Api.Models.Entity;
using MySimpleStock.Api.Repositories;

namespace MySimpleStock.Api.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContextApi context) : base(context)
        {
        }
    }
}
