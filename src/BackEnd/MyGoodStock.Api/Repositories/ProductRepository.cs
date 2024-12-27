using MyGoodStock.Api.Context;
using MyGoodStock.Api.Models.Entity;

namespace MyGoodStock.Api.Repositories
{
    public class ProductRepository : BaseRepository<StockMovement>, IProductRepository
    {
        public ProductRepository(ApplicationDbContextApi context) : base(context)
        {
        }
    }
}
