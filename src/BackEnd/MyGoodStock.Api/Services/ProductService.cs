using AutoMapper;
using FluentValidation;
using MyGoodStock.Api.Models.Entity;
using MyGoodStock.Api.Models.ViewModel;
using MyGoodStock.Api.Repositories;

namespace MyGoodStock.Api.Services
{
    public class ProductService : BaseService<ProductViewModel, Product>, IProductService
    {
        public ProductService(BaseRepository<Product> repository, IMapper mapper, IValidator<ProductViewModel> validator) : base(repository, mapper, validator)
        {
        }
    }
}
