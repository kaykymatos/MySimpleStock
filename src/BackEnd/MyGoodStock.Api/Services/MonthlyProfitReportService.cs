using AutoMapper;
using FluentValidation;
using MyGoodStock.Api.Models.Entity;
using MyGoodStock.Api.Models.ViewModel;
using MyGoodStock.Api.Repositories;

namespace MyGoodStock.Api.Services
{
    public class MonthlyProfitReportService : BaseService<MonthlyProfitReportViewModel, MonthlyProfitReport>, IMonthlyProfitReportService
    {
        public MonthlyProfitReportService(BaseRepository<MonthlyProfitReport> repository, IMapper mapper, IValidator<MonthlyProfitReportViewModel> validator) : base(repository, mapper, validator)
        {
        }
    }
}
