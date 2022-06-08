﻿using ETradeAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Repositories.IdentityRepository
{
    public interface IUserReadRepository:IReadRepository<User>
    {
    }
}
