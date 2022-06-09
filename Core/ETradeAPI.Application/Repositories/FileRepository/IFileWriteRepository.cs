﻿using Common.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Repositories.FileRepository
{
    public interface IFileWriteRepository: IWriteRepository<Domain.Entities.File>
    {
    }
}
