using MySimpleStock.Api.Context;
using MySimpleStock.Api.Models.Entity;
using MySimpleStock.Api.Repositories;

namespace MySimpleStock.Api.Repositories
{
    public class SaleRepository : BaseRepository<Sale>, ISaleRepository
    {
        public SaleRepository(ApplicationDbContextApi context) : base(context)
        {
        }
    }
}
