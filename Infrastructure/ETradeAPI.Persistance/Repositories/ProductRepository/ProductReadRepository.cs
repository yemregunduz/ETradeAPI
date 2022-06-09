using Common.Application.Repositories;
using ETradeAPI.Application.Repositories.ProductRepository;
using ETradeAPI.Domain.Entities;
using ETradeAPI.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistance.Repositories.ProductRepository
{
    public class ProductReadRepository : ReadRepository<Product,ETradeAPIDbContext>, IProductReadRepository
    {
        public ProductReadRepository(ETradeAPIDbContext context) : base(context)
        {
        }
    }
}
