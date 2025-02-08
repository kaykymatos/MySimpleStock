using AutoMapper;
using FluentValidation;
using MySimpleStock.Api.Models;
using MySimpleStock.Api.Models.Entity;
using MySimpleStock.Api.Models.ViewModel;
using MySimpleStock.Api.Repositories;

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

                var res = await _repository.CreateAsync(new Sale
                {
                    ClientId = Guid.Parse(sale.ClientId),
                    CreationDate = DateTime.UtcNow,
                    TotalValue = sale.TotalValue,
                    UserId = Guid.Parse(sale.UserId),
                    Id = Guid.Empty,
                    Date = DateTime.UtcNow,

                });

                foreach (var item in sale.SaleItems)
                {
                    item.UserId = res.UserId.ToString();
                    item.SaleId = res.Id.ToString();
                    item.Id = Guid.Empty.ToString();
                    await _saleItemRepository.CreateAsync(new SaleItem
                    {
                        Id = Guid.Empty,
                        CreationDate = DateTime.UtcNow,
                        Price = item.Price,
                        ProductId = Guid.Parse(item.ProductId),
                        Quantity = item.Quantity,
                        SaleId = Guid.Parse(item.SaleId),
                        UserId = Guid.Parse(sale.UserId),
                    });
                }


                var existentMonthlyProfitReport = await _monthlyProfitReportRepository.GetMonthlyProfitReportByMonth(sale.Date.Month, sale.Date.Year, Guid.Parse(sale.UserId));

                if (existentMonthlyProfitReport != null)
                {
                    existentMonthlyProfitReport.TotalProfit += sale.TotalValue;
                    await _monthlyProfitReportRepository.UpdateAsync(existentMonthlyProfitReport);
                }
                else
                {

                    await _monthlyProfitReportRepository.CreateAsync(new MonthlyProfitReport
                    {
                        CreationDate = DateTime.Now,
                        Month = sale.Date.Month,
                        UserId = Guid.Parse(sale.UserId),
                        Id = Guid.Empty,
                        TotalProfit = sale.TotalValue,
                    });
                }


                return new ResponseApiModel<SaleViewModel>(sale);
            }
            catch (Exception)
            {
                return new ResponseApiModel<SaleViewModel>("Erro interno no servidor!");
            }


        }

        public override async Task<IEnumerable<SaleViewModel>> GetAllAsync(Guid userId)
        {
            var res = await _repositoryRepository.GetAllSales(userId);
            return _mapper.Map<IEnumerable<SaleViewModel>>(res);
        }

    }
}
