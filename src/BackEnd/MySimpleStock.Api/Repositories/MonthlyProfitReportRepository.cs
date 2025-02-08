using Microsoft.EntityFrameworkCore;
using MySimpleStock.Api.Context;
using MySimpleStock.Api.Models.Entity;

namespace MySimpleStock.Api.Repositories
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

        public async Task<MonthlyProfitReport> GetMonthlyProfitReportByMonth(int month, int year, Guid userId)
        {
            return await _context.MonthlyProfitReports.FirstOrDefaultAsync(x => x.Month == month && x.Year == year && x.UserId == userId);
        }
    }
}
