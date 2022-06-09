using ETradeAPI.Application.Repositories.OrderRepository;
using ETradeAPI.Domain.Entities;
using ETradeAPI.Persistance.Context;


namespace ETradeAPI.Persistance.Repositories.OrderRepository
{
    public class OrderWriteRepository : WriteRepository<Order,ETradeAPIDbContext>, IOrderWriteRepository
    {
        public OrderWriteRepository(ETradeAPIDbContext context) : base(context)
        {
        }
    }
}
