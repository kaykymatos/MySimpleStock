using MySimpleStock.Api.Models.ViewModel;

namespace MySimpleStock.Api.Services
{
    public interface IMonthlyProfitReportService : IBaseService<MonthlyProfitReportViewModel>
    {
        Task<MonthlyProfitReportViewModel> GetMonthlyProfitReportByMonth(int month, int year, Guid userId);
    }
}
