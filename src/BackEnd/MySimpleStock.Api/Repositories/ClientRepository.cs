using MySimpleStock.Api.Context;
using MySimpleStock.Api.Models.Entity;
using MySimpleStock.Api.Repositories;

namespace MySimpleStock.Api.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(ApplicationDbContextApi context) : base(context)
        {
        }
    }
}
