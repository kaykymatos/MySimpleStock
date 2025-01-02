using AutoMapper;
using FluentValidation;
using MySimpleStock.Api.Models.Entity;
using MySimpleStock.Api.Models.ViewModel;
using MySimpleStock.Api.Repositories;
using MySimpleStock.Api.Services;

namespace MySimpleStock.Api.Services
{
    public class SaleService : BaseService<SaleViewModel, Sale>, ISaleService
    {
        public SaleService(BaseRepository<Sale> repository, IMapper mapper, IValidator<SaleViewModel> validator) : base(repository, mapper, validator)
        {
        }
    }
}
