using AutoMapper;
using FluentValidation;
using MySimpleStock.Api.Models.Entity;
using MySimpleStock.Api.Models.ViewModel;
using MySimpleStock.Api.Repositories;
using MySimpleStock.Api.Services;

namespace MySimpleStock.Api.Services
{
    public class MonthlyProfitReportService : BaseService<MonthlyProfitReportViewModel, MonthlyProfitReport>, IMonthlyProfitReportService
    {
        private readonly IMonthlyProfitReportRepository _repostory;
        public MonthlyProfitReportService(BaseRepository<MonthlyProfitReport> baseRepository, IMonthlyProfitReportRepository repository, IMapper mapper, IValidator<MonthlyProfitReportViewModel> validator) : base(baseRepository, mapper, validator)
        {
            _repostory = repository;
        }

        public async Task<MonthlyProfitReportViewModel> GetMonthlyProfitReportByMonth(int month, Guid userId)
        {
            return _mapper.Map<MonthlyProfitReportViewModel>(await _repostory.GetMonthlyProfitReportByMonth(month, userId));
        }
    }
}
