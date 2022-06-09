using Common.Application.Repositories;
using ETradeAPI.Application.Repositories.OrderRepository;
using ETradeAPI.Domain.Entities;
using ETradeAPI.Persistance.Context;

namespace ETradeAPI.Persistance.Repositories.OrderRepository
{
    public class OrderReadRepository : ReadRepository<Order,ETradeAPIDbContext>, IOrderReadRepository
    {
        public OrderReadRepository(ETradeAPIDbContext context) : base(context)
        {
        }
    }
}
