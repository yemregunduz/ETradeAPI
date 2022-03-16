﻿using ETradeAPI.Application.Repositories.ProductRepository;
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
        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }
        [HttpGet]
        public async void Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new() { Id = Guid.NewGuid(),Name ="Product1",UnitPrice =100,CreatedDate = DateTime.UtcNow,Stock=10 },
                new() { Id = Guid.NewGuid(), Name = "Product2", UnitPrice = 200, CreatedDate = DateTime.UtcNow, Stock = 10 },
                new() { Id = Guid.NewGuid(), Name = "Product3", UnitPrice = 300, CreatedDate = DateTime.UtcNow, Stock = 10 },
            });
            _productWriteRepository.SaveAsync(); 
        }

    }
}
