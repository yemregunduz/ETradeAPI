using AutoMapper;
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
    public class UpdateProductCommand:IRequest<UpdateProductCommand>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public float UnitPrice { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductCommand>
        {
            private readonly IProductWriteRepository _productWriteRepository;
            private readonly IMapper _mapper;

            public UpdateProductCommandHandler(IProductWriteRepository productWriteRepository, IMapper mapper)
            {
                _productWriteRepository = productWriteRepository;
                _mapper = mapper;
            }

            public async Task<UpdateProductCommand> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                Product product = _mapper.Map<Product>(request);
                await _productWriteRepository.Update(product);
                return request;
            }
        }
    }
}
