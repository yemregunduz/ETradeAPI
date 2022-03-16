using ETradeAPI.Application.Repositories.CustomerRepository;
using ETradeAPI.Domain.Entities;
using ETradeAPI.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistance.Repositories.CustomerRepository
{
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(ETradeAPIDbContext context) : base(context)
        {
        }
    }
}
