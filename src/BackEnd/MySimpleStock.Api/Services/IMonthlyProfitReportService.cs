using MySimpleStock.Api.Models.ViewModel;
using MySimpleStock.Api.Services;

namespace MySimpleStock.Api.Services
{
    public interface IMonthlyProfitReportService : IBaseService<MonthlyProfitReportViewModel>
    {
        Task<MonthlyProfitReportViewModel> GetMonthlyProfitReportByMonth(int month, Guid userId);
    }
}
