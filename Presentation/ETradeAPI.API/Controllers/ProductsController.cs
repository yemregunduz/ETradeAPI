using ETradeAPI.Application.Features.Products.Commands;
using ETradeAPI.Application.Features.Products.Dtos;
using ETradeAPI.Application.Features.Products.Models;
using ETradeAPI.Application.Features.Products.Queries;
using ETradeAPI.Application.Parameters;
using ETradeAPI.Application.Repositories.ProductRepository;
using ETradeAPI.Application.ViewModels.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ETradeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator,IWebHostEnvironment webHostEnvironment)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest requestParameter )
        {
            GetProductListQuery getProductListQuery = new() { RequestParameter = requestParameter};
            ProductListModel result = await _mediator.Send(getProductListQuery);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            GetProductByIdQuery getProductByIdQuery = new() { Id=id};
            ProductListDto result = await _mediator.Send(getProductByIdQuery);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductCommand createProductCommand)
        {
            var id = await _mediator.Send(createProductCommand);
            return Created("", id);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
        {
            var response = await _mediator.Send(updateProductCommand);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            DeleteProductByIdCommand deleteProductByIdCommand = new() { Id = id };
            var response = await _mediator.Send(deleteProductByIdCommand);
            if (response==true)
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}
