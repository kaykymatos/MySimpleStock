using MyGoodStock.Api.Context;
using MyGoodStock.Api.Models.Entity;

namespace MyGoodStock.Api.Repositories
{
    public class SaleRepository : BaseRepository<Sale>, ISaleRepository
    {
        public SaleRepository(ApplicationDbContextApi context) : base(context)
        {
        }
    }
}
