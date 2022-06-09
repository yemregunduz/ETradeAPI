using Common.Application.Repositories;
using ETradeAPI.Application.Repositories.FileRepository;
using ETradeAPI.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistance.Repositories.FileRepository
{
    public class FileReadRepository : ReadRepository<Domain.Entities.File,ETradeAPIDbContext>, IFileReadRepository
    {
        public FileReadRepository(ETradeAPIDbContext context) : base(context)
        {
        }
    }
}
