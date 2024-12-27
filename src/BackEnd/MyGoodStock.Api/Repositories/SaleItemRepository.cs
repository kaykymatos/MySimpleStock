using MyGoodStock.Api.Context;
using MyGoodStock.Api.Models.Entity;

namespace MyGoodStock.Api.Repositories
{
    public class SaleItemRepository : BaseRepository<SaleItem>, ISaleItemRepository
    {
        public SaleItemRepository(ApplicationDbContextApi context) : base(context)
        {
        }
    }
}
