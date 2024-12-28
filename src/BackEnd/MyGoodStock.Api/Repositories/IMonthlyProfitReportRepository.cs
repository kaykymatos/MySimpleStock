using MyGoodStock.Api.Models.Entity;

namespace MyGoodStock.Api.Repositories
{
    public interface IMonthlyProfitReportRepository : IBaseRepository<MonthlyProfitReport>
    {
        Task<MonthlyProfitReport> GetMonthlyProfitReportByMonth(int month, Guid userId);
    }
}
