using MySimpleStock.Api.Models.Entity;

namespace MySimpleStock.Api.Repositories
{
    public interface IMonthlyProfitReportRepository : IBaseRepository<MonthlyProfitReport>
    {
        Task<MonthlyProfitReport> GetMonthlyProfitReportByMonth(int month, int year, Guid userId);
    }
}
