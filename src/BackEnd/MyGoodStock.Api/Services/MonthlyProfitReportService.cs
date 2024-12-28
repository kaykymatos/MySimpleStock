using AutoMapper;
using FluentValidation;
using MyGoodStock.Api.Models.Entity;
using MyGoodStock.Api.Models.ViewModel;
using MyGoodStock.Api.Repositories;

namespace MyGoodStock.Api.Services
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
