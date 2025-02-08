using MySimpleStock.Api.Context;
using MySimpleStock.Api.Models.Entity;

namespace MySimpleStock.Api.Repositories
{
    public class SaleItemRepository : BaseRepository<SaleItem>, ISaleItemRepository
    {
        public SaleItemRepository(ApplicationDbContextApi context) : base(context)
        {
        }
    }
}
