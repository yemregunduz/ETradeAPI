using Common.Application.Repositories;
using ETradeAPI.Application.Repositories.FileRepository.ProductImageFileRepository;
using ETradeAPI.Domain.Entities;
using ETradeAPI.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistance.Repositories.FileRepository.ProductImageFileRepository
{
    public class ProductImageFileReadRepository : ReadRepository<ProductImageFile,ETradeAPIDbContext>, IProductImageFileReadRepository
    {
        public ProductImageFileReadRepository(ETradeAPIDbContext context) : base(context)
        {
        }
    }
}
