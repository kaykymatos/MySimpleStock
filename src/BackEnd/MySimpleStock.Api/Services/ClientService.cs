using AutoMapper;
using FluentValidation;
using MySimpleStock.Api.Models.Entity;
using MySimpleStock.Api.Models.ViewModel;
using MySimpleStock.Api.Repositories;
using MySimpleStock.Api.Services;

namespace MySimpleStock.Api.Services
{
    public class ClientService : BaseService<ClientViewModel, Client>, IClientService
    {
        public ClientService(BaseRepository<Client> repository, IMapper mapper, IValidator<ClientViewModel> validator) : base(repository, mapper, validator)
        {
        }
    }
}
