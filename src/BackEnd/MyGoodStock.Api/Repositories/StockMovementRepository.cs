using MyGoodStock.Api.Context;
using MyGoodStock.Api.Models.Entity;

namespace MyGoodStock.Api.Repositories
{
    public class StockMovementRepository : BaseRepository<StockMovement>, IStockMovementRepository
    {
        public StockMovementRepository(ApplicationDbContextApi context) : base(context)
        {
        }
    }
}
