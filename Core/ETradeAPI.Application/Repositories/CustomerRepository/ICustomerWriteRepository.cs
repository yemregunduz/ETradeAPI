using Common.Application.Repositories;
using ETradeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Repositories.CustomerRepository
{
    public interface ICustomerWriteRepository: IWriteRepository<Customer>
    {
    }
}
