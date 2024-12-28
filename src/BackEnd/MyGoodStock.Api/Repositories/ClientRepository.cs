using MyGoodStock.Api.Context;
using MyGoodStock.Api.Models.Entity;

namespace MyGoodStock.Api.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(ApplicationDbContextApi context) : base(context)
        {
        }
    }
}
