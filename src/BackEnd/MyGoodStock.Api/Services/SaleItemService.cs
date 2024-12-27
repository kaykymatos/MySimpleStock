using AutoMapper;
using FluentValidation;
using MyGoodStock.Api.Models.Entity;
using MyGoodStock.Api.Models.ViewModel;
using MyGoodStock.Api.Repositories;

namespace MyGoodStock.Api.Services
{
    public class SaleItemService : BaseService<SaleItemViewModel, SaleItem>, ISaleItemService
    {
        public SaleItemService(BaseRepository<SaleItem> repository, IMapper mapper, IValidator<SaleItemViewModel> validator) : base(repository, mapper, validator)
        {
        }
    }
}
