using ETradeAPI.Application.Features.Products.Commands;
using ETradeAPI.Application.Features.Products.Dtos;
using ETradeAPI.Application.Features.Products.Models;
using ETradeAPI.Application.Features.Products.Queries;
using ETradeAPI.Application.Parameters;
using ETradeAPI.Application.Repositories.FileRepository;
using ETradeAPI.Application.Repositories.FileRepository.InvoiceFileRepository;
using ETradeAPI.Application.Repositories.FileRepository.ProductImageFileRepository;
using ETradeAPI.Application.Repositories.ProductRepository;
using ETradeAPI.Application.Services;
using ETradeAPI.Application.ViewModels.Products;
using ETradeAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ETradeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IFileService _fileService;
        private readonly IFileWriteRepository _fileWriteRepository;
        private readonly IFileReadRepository _fileReadRepository;
        private readonly IProductImageFileReadRepository _productImageFileReadRepository;
        private readonly IProductImageFileWriteRepository _productImageFileWriteRepository;
        private readonly IInvoiceFileReadRepository _invoiceFileReadRepository;
        private readonly IInvoiceFileWriteRepository _invoiceFileWriteRepository;

        public ProductsController(IMediator mediator, IWebHostEnvironment webHostEnvironment, IFileService fileService, IFileWriteRepository fileWriteRepository, IFileReadRepository fileReadRepository, IProductImageFileReadRepository productImageFileReadRepository, IProductImageFileWriteRepository productImageFileWriteRepository, IInvoiceFileReadRepository invoiceFileReadRepository, IInvoiceFileWriteRepository invoiceFileWriteRepository)
        {
            _mediator = mediator;
            _fileService = fileService;
            _fileWriteRepository = fileWriteRepository;
            _fileReadRepository = fileReadRepository;
            _productImageFileReadRepository = productImageFileReadRepository;
            _productImageFileWriteRepository = productImageFileWriteRepository;
            _invoiceFileReadRepository = invoiceFileReadRepository;
            _invoiceFileWriteRepository = invoiceFileWriteRepository;
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
        [HttpPost("[action]")]
        public async Task<IActionResult> Upload()
        {
            var datas = await _fileService.UploadAsync("resource/files",Request.Form.Files);
            //await _productImageFileWriteRepository.AddRangeAsync(datas.Select(d => new ProductImageFile()
            //{
            //    FileName = d.fileName,
            //    Path= d.path
            //}).ToList());
            //await _invoiceFileWriteRepository.AddRangeAsync(datas.Select(d => new InvoiceFile()
            //{
            //    FileName = d.fileName,
            //    Path = d.path,
            //    Price = new Random().Next()
            ////}).ToList());
            //await _fileWriteRepository.AddRangeAsync(datas.Select(d => new Domain.Entities.File()
            //{
            //    FileName = d.fileName,
            //    Path = d.path,
            //}).ToList());
            //var d1= await _fileReadRepository.GetListAsync();
            //var d2= await _invoiceFileReadRepository.GetListAsync();
            //var d3= await _productImageFileReadRepository.GetListAsync();
            return Ok();
        }

    }
}
