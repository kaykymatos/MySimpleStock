using MyGoodStock.Api.Context;
using MyGoodStock.Api.Models.Entity;

namespace MyGoodStock.Api.Repositories
{
    public class MonthlyProfitReportRepository : BaseRepository<MonthlyProfitReport>, IMonthlyProfitReportRepository
    {
        public MonthlyProfitReportRepository(ApplicationDbContextApi context) : base(context)
        {
        }
    }
}
