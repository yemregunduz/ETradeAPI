using AutoMapper;
using Common.Application.Wrappers.Results.Abstract;
using Common.Application.Wrappers.Results.Concrete;
using ETradeAPI.Application.Repositories.ProductRepository;
using ETradeAPI.Domain.Constants;
using ETradeAPI.Domain.Entities;
using MediatR;

namespace ETradeAPI.Application.Features.Products.Commands
{
    public class CreateProductCommand:IRequest<IDataResult<Product>>
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public float UnitPrice { get; set; }
        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, IDataResult<Product>>
        {
            private readonly IProductWriteRepository _productWriteRepository;
            private readonly IMapper _mapper;
            public CreateProductCommandHandler(IProductWriteRepository productWriteRepository, IMapper mapper)
            {
                _productWriteRepository = productWriteRepository;
                _mapper = mapper;
            }
            public async Task<IDataResult<Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                Product product = _mapper.Map<Product>(request);
                await _productWriteRepository.AddAsync(product);
                return new SuccessDataResult<Product>(product, Messages.ProductAdded);
            }
        }
    }
}
