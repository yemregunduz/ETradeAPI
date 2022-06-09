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
    public class ProductWriteRepository : WriteRepository<Product,ETradeAPIDbContext>, IProductWriteRepository
    {
        public ProductWriteRepository(ETradeAPIDbContext context) : base(context)
        {
        }
    }
}
