using ETradeAPI.Application.Features.Products.Models;
using ETradeAPI.Application.Features.Products.Queries;
using ETradeAPI.Application.Parameters;
using ETradeAPI.Application.Repositories.CustomerRepository;
using ETradeAPI.Application.Repositories.OrderRepository;
using ETradeAPI.Application.Repositories.ProductRepository;
using ETradeAPI.Application.ViewModels.Products;
using ETradeAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ETradeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] RequestParameter requestParameter )
        {
            GetProductListQuery getProductListQuery = new() { RequestParameter = requestParameter};
            ProductListModel result = await _mediator.Send(getProductListQuery);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
          
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Add(VM_CreateProduct model)
        {
            return Ok((int)HttpStatusCode.Created);
        }
        [HttpPut]
        public async Task<IActionResult> Update(VM_UpdateProduct model)
        {
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok();
        }
    }
}
