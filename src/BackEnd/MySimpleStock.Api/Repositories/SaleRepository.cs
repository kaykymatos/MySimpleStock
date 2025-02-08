using Microsoft.EntityFrameworkCore;
using MySimpleStock.Api.Context;
using MySimpleStock.Api.Models.Entity;

namespace MySimpleStock.Api.Repositories
{
    public class SaleRepository : BaseRepository<Sale>, ISaleRepository
    {
        public SaleRepository(ApplicationDbContextApi context) : base(context)
        {
        }
        public async Task<IEnumerable<Sale>> GetAllSales(Guid userId)
        {
            return await _context.Sales.Include(x => x.SaleItems).ThenInclude(si => si.Product).Include(x => x.Client).Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
