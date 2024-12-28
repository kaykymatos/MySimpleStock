using Microsoft.EntityFrameworkCore;
using MyGoodStock.Api.Context;
using MyGoodStock.Api.Models.Entity;

namespace MyGoodStock.Api.Repositories
{
    public class MonthlyProfitReportRepository : BaseRepository<MonthlyProfitReport>, IMonthlyProfitReportRepository
    {
        protected readonly ApplicationDbContextApi _context;
        public MonthlyProfitReportRepository(ApplicationDbContextApi context) : base(context)
        {
            _context = context;
        }

        public async Task<MonthlyProfitReport> GetMonthlyProfitReportByMonth(int month, Guid userId)
        {
            return await _context.MonthlyProfitReports.FirstOrDefaultAsync(x => x.Month == month && x.UserId == userId);
        }
    }
}
