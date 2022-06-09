using Common.Security.Entities;
using ETradeAPI.Application.Repositories.UserOperationClaimRepository;
using ETradeAPI.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistance.Repositories.UserOperationClaimRepository
{
    public class UserOperationClaimWriteRepository : WriteRepository<UserOperationClaim,ETradeAPIDbContext>, IUserOperationClaimWriteRepository
    {
        public UserOperationClaimWriteRepository(ETradeAPIDbContext context) : base(context)
        {
        }
    }
}
