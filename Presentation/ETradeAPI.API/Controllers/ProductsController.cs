using ETradeAPI.Application.Features.Products.Commands;
using ETradeAPI.Application.Features.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetList([FromQuery] GetProductListQuery getProductListQuery)
        {

            var result = await _mediator.Send(getProductListQuery);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetProductByIdQuery getProductByIdQuery)
        {
            var result = await _mediator.Send(getProductByIdQuery);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateProductCommand createProductCommand)
        {
            var result = await _mediator.Send(createProductCommand);
            if (result.Success==true)
            {
                return Created("", result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand? updateProductCommand)
        {
            var result = await _mediator.Send(updateProductCommand);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProductByIdCommand deleteProductByIdCommand)
        {
            var result = await _mediator.Send(deleteProductByIdCommand);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
