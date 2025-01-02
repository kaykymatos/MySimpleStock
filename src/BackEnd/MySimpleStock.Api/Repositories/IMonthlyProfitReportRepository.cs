using MySimpleStock.Api.Models.Entity;
using MySimpleStock.Api.Repositories;

namespace MySimpleStock.Api.Repositories
{
    public interface IMonthlyProfitReportRepository : IBaseRepository<MonthlyProfitReport>
    {
        Task<MonthlyProfitReport> GetMonthlyProfitReportByMonth(int month, Guid userId);
    }
}
