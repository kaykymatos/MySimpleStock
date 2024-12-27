using AutoMapper;
using FluentValidation;
using MyGoodStock.Api.Models.Entity;
using MyGoodStock.Api.Models.ViewModel;
using MyGoodStock.Api.Repositories;

namespace MyGoodStock.Api.Services
{
    public class StockMovementService : BaseService<StockMovementViewModel, StockMovement>, IStockMovementService
    {
        public StockMovementService(BaseRepository<StockMovement> repository, IMapper mapper, IValidator<StockMovementViewModel> validator) : base(repository, mapper, validator)
        {
        }
    }
}
