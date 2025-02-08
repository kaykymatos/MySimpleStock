using AutoMapper;
using FluentValidation;
using MySimpleStock.Api.Models.Entity;
using MySimpleStock.Api.Models.ViewModel;
using MySimpleStock.Api.Repositories;

namespace MySimpleStock.Api.Services
{
    public class SaleItemService : BaseService<SaleItemViewModel, SaleItem>, ISaleItemService
    {
        public SaleItemService(BaseRepository<SaleItem> repository, IMapper mapper, IValidator<SaleItemViewModel> validator) : base(repository, mapper, validator)
        {
        }
    }
}
