using ETradeAPI.Application.Repositories.IdentityRepository;
using ETradeAPI.Domain.Entities.Identity;
using ETradeAPI.Persistance.Context;

namespace ETradeAPI.Persistance.Repositories.UserRepository
{
    public class UserWriteRepository : WriteRepository<User>, IUserWriteRepository
    {
        public UserWriteRepository(ETradeAPIDbContext context) : base(context)
        {
        }
    }
}
