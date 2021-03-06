using AutoMapper;
using Common.Application.BusinessRules;
using Common.Application.Wrappers.Results.Abstract;
using Common.Application.Wrappers.Results.Concrete;
using ETradeAPI.Application.Features.Products.Rules;
using ETradeAPI.Application.Repositories.ProductRepository;
using ETradeAPI.Domain.Constants;
using ETradeAPI.Domain.Entities;
using MediatR;

namespace ETradeAPI.Application.Features.Products.Commands
{
    public class UpdateProductCommand:IRequest<IDataResult<Product>>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public float UnitPrice { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, IDataResult<Product>>
        {
            private readonly IProductWriteRepository _productWriteRepository;
            private readonly IMapper _mapper;
            private readonly ProductBusinessRules _productBusinessRules;
            public UpdateProductCommandHandler(IProductWriteRepository productWriteRepository, IMapper mapper, ProductBusinessRules productBusinessRules)
            {
                _productWriteRepository = productWriteRepository;
                _mapper = mapper;
                _productBusinessRules = productBusinessRules;
            }

            public async Task<IDataResult<Product>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                IResult result = BusinessRules.Run(await _productBusinessRules.CheckProductIsExist(request.Id));
                if (result != null)
                {
                    return new ErrorDataResult<Product>(result.Message);
                }
                Product product = _mapper.Map<Product>(request);
                var updateResult = await _productWriteRepository.Update(product);
                return new SuccessDataResult<Product>(product,Messages.ProductUpdated);
            }
        }
    }
}
