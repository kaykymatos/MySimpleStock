using AutoMapper;
using FluentValidation;
using MySimpleStock.Api.Models.Entity;
using MySimpleStock.Api.Models.ViewModel;
using MySimpleStock.Api.Repositories;

namespace MySimpleStock.Api.Services
{
    public class ProductService : BaseService<ProductViewModel, Product>, IProductService
    {
        public ProductService(BaseRepository<Product> repository, IMapper mapper, IValidator<ProductViewModel> validator) : base(repository, mapper, validator)
        {
        }
    }
}
