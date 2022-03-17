﻿using ETradeAPI.Application.Repositories.ProductRepository;
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
        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            //await _productWriteRepository.AddRangeAsync(new()
            //{
            //    new() { Id = Guid.NewGuid(),Name ="Product1",UnitPrice =100,CreatedDate = DateTime.UtcNow,Stock=10 },
            //    new() { Id = Guid.NewGuid(), Name = "Product2", UnitPrice = 200, CreatedDate = DateTime.UtcNow, Stock = 10 },
            //    new() { Id = Guid.NewGuid(), Name = "Product3", UnitPrice = 300, CreatedDate = DateTime.UtcNow, Stock = 10 },
            //});
            //_productWriteRepository.SaveAsync(); 
            Product p = await _productReadRepository.GetByIdAsync("8a976470-54a6-46be-ada6-08e1ace916ce",false);
            p.Name = "Pantolon";
            await _productWriteRepository.SaveAsync();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }

    }
}
