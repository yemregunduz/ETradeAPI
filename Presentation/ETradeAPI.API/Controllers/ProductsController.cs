using ETradeAPI.Application.Repositories.CustomerRepository;
using ETradeAPI.Application.Repositories.OrderRepository;
using ETradeAPI.Application.Repositories.ProductRepository;
using ETradeAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETradeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        readonly private IOrderWriteRepository _orderWriteRepository;
        readonly IOrderReadRepository _orderReadRepository;

        readonly private ICustomerWriteRepository _customerWriteRepository;
        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository,
            IOrderReadRepository orderReadRepository,IOrderWriteRepository orderWriteRepository,ICustomerWriteRepository customerWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            var order = await _orderReadRepository.GetByIdAsync("16aad464-f936-42ba-bca1-1c2e60dd527c");
            order.Address = "İzmir";
            await _orderWriteRepository.SaveAsync();
            
        }
        

    }
}
