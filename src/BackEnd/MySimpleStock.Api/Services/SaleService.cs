using AutoMapper;
using FluentValidation;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MySimpleStock.Api.Models;
using MySimpleStock.Api.Models.Entity;
using MySimpleStock.Api.Models.ViewModel;
using MySimpleStock.Api.Repositories;
using MySimpleStock.Api.Services;

namespace MySimpleStock.Api.Services
{
    public class SaleService : BaseService<SaleViewModel, Sale>, ISaleService
    {
        private readonly IMonthlyProfitReportRepository _monthlyProfitReportRepository;
        private readonly ISaleItemRepository _saleItemRepository;
        private readonly ISaleRepository _repositoryRepository;

        public SaleService(BaseRepository<Sale> repository, ISaleRepository repositoryRepository, ISaleItemRepository saleItemRepository, IMapper mapper, IValidator<SaleViewModel> validator, IMonthlyProfitReportRepository monthlyProfitReportRepository) : base(repository, mapper, validator)
        {
            _monthlyProfitReportRepository = monthlyProfitReportRepository;
            _saleItemRepository = saleItemRepository;
            _repositoryRepository = repositoryRepository;
        }
        public override async Task<ResponseApiModel<SaleViewModel>> CreateAsync(SaleViewModel sale)
        {

            sale.TotalValue = sale.SaleItems.Sum(item => item.Quantity * item.Price);
            var validation = _validator.Validate(sale);
            if (!validation.IsValid)
                return new ResponseApiModel<SaleViewModel>(validation.Errors);
            try
            {
                sale.Id = Guid.Empty.ToString();

                var res = await _repository.CreateAsync(_mapper.Map<Sale>(sale));

                foreach (var item in sale.SaleItems)
                {
                    item.UserId = res.UserId.ToString();
                    item.SaleId = res.Id.ToString();
                    item.Id=Guid.Empty.ToString();
                    await _saleItemRepository.CreateAsync(_mapper.Map<SaleItem>(item));
                }


                var existentMonthlyProfitReport = await _monthlyProfitReportRepository.GetMonthlyProfitReportByMonth(sale.Date.Month, Guid.Parse(sale.UserId));

                if (existentMonthlyProfitReport != null)
                {
                    existentMonthlyProfitReport.TotalProfit += sale.TotalValue;
                    await _monthlyProfitReportRepository.UpdateAsync(existentMonthlyProfitReport);
                }
                else
                {

                    await _monthlyProfitReportRepository.CreateAsync(new MonthlyProfitReport
                    {
                        CreationDate=DateTime.Now,
                        Month = sale.Date.Month,
                        UserId = Guid.Parse(sale.UserId),
                        Id= Guid.Empty,
                        TotalProfit = sale.TotalValue,
                    });
                }


                return new ResponseApiModel<SaleViewModel>(sale);
            }
            catch (Exception ex)
            {
                return new ResponseApiModel<SaleViewModel>("Erro interno no servidor!");
            }

            
        }

        public override async Task<IEnumerable<SaleViewModel>> GetAllAsync(Guid userId)
        {
            var res = await _repositoryRepository.GetAllSales(userId);
            var b = _mapper.Map<IEnumerable<SaleViewModel>>(res);
            return _mapper.Map<IEnumerable<SaleViewModel>>(res);
        }

    }
}
