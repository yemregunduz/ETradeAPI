using Common.Security.Entities;
using ETradeAPI.Application.Repositories.IdentityRepository;
using ETradeAPI.Persistance.Context;

namespace ETradeAPI.Persistance.Repositories.UserRepository
{
    public class UserWriteRepository : WriteRepository<User,ETradeAPIDbContext>, IUserWriteRepository
    {
        public UserWriteRepository(ETradeAPIDbContext context) : base(context)
        {
        }
    }
}
