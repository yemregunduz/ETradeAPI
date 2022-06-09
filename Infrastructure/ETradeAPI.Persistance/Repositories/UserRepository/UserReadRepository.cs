using Common.Application.Repositories;
using Common.Security.Entities;
using ETradeAPI.Application.Repositories.IdentityRepository;
using ETradeAPI.Persistance.Context;

namespace ETradeAPI.Persistance.Repositories.UserRepository
{
    public class UserReadRepository : ReadRepository<User,ETradeAPIDbContext>, IUserReadRepository
    {
        public UserReadRepository(ETradeAPIDbContext context) : base(context)
        {
        }
    }
}
