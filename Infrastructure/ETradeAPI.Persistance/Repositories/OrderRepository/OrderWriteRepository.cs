using ETradeAPI.Application.Repositories.OrderRepository;
using ETradeAPI.Domain.Entities;
using ETradeAPI.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistance.Repositories.OrderRepository
{
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(ETradeAPIDbContext context) : base(context)
        {
        }
    }
}
