using ETradeAPI.Application.Repositories.IdentityRepository;
using ETradeAPI.Domain.Entities.Identity;
using ETradeAPI.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistance.Repositories.UserRepository
{
    public class UserReadRepository : ReadRepository<User>, IUserReadRepository
    {
        public UserReadRepository(ETradeAPIDbContext context) : base(context)
        {
        }
    }
}
