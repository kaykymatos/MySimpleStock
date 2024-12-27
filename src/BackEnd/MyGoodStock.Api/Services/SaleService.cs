using AutoMapper;
using FluentValidation;
using MyGoodStock.Api.Models.Entity;
using MyGoodStock.Api.Models.ViewModel;
using MyGoodStock.Api.Repositories;

namespace MyGoodStock.Api.Services
{
    public class SaleService : BaseService<SaleViewModel, Sale>, ISaleService
    {
        public SaleService(BaseRepository<Sale> repository, IMapper mapper, IValidator<SaleViewModel> validator) : base(repository, mapper, validator)
        {
        }
    }
}
