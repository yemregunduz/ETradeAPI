using AutoMapper;
using ETradeAPI.Application.Features.Products.Dtos;
using ETradeAPI.Application.Repositories.ProductRepository;
using ETradeAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Products.Commands
{
    public class CreateProductCommand:IRequest<Guid>
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public float UnitPrice { get; set; }
        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
        {
            private readonly IProductWriteRepository _productWriteRepository;
            private readonly IMapper _mapper;
            public CreateProductCommandHandler(IProductWriteRepository productWriteRepository, IMapper mapper)
            {
                _productWriteRepository = productWriteRepository;
                _mapper = mapper;
            }
            public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                Product product = _mapper.Map<Product>(request);
                await _productWriteRepository.AddAsync(product);
                return product.Id;
            }
        }
    }
}
