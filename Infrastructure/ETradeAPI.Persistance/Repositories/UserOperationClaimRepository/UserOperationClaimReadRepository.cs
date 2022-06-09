using Common.Application.Repositories;
using Common.Security.Entities;
using ETradeAPI.Application.Repositories.UserOperationClaimRepository;
using ETradeAPI.Persistance.Context;


namespace ETradeAPI.Persistance.Repositories.UserOperationClaimRepository
{
    public class UserOperationClaimReadRepository : ReadRepository<UserOperationClaim,ETradeAPIDbContext>, IUserOperationClaimReadRepository
    {
        public UserOperationClaimReadRepository(ETradeAPIDbContext context) : base(context)
        {
        }
    }
}
