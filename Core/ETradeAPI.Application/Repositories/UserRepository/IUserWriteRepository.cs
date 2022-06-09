using Common.Application.Repositories;
using Common.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Repositories.IdentityRepository
{
    public interface IUserWriteRepository:IWriteRepository<User>
    {
    }
}
