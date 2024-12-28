using AutoMapper;
using FluentValidation;
using MyGoodStock.Api.Models.Entity;
using MyGoodStock.Api.Models.ViewModel;
using MyGoodStock.Api.Repositories;

namespace MyGoodStock.Api.Services
{
    public class ClientService : BaseService<ClientViewModel, Client>, IClientService
    {
        public ClientService(BaseRepository<Client> repository, IMapper mapper, IValidator<ClientViewModel> validator) : base(repository, mapper, validator)
        {
        }
    }
}
