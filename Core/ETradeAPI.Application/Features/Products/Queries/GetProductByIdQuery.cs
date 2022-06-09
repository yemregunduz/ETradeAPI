using AutoMapper;
using Common.Application.Wrappers.Results.Abstract;
using Common.Application.Wrappers.Results.Concrete;
using ETradeAPI.Application.Features.Products.Dtos;
using ETradeAPI.Application.Repositories.ProductRepository;
using ETradeAPI.Domain.Constants;
using MediatR;


namespace ETradeAPI.Application.Features.Products.Queries
{
    public class GetProductByIdQuery:IRequest<IDataResult<ProductListDto>>
    {
        public string Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, IDataResult<ProductListDto>>
        {
            private readonly IProductReadRepository _productReadRepository;
            private readonly IMapper _mapper;
            public GetProductByIdQueryHandler(IProductReadRepository productReadRepository, IMapper mapper)
            {
                _productReadRepository = productReadRepository;
                _mapper = mapper;
            }
            public async Task<IDataResult<ProductListDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var product = await _productReadRepository.GetByIdAsync(request.Id);
                ProductListDto model = _mapper.Map<ProductListDto>(product);
                return new SuccessDataResult<ProductListDto>(model,Messages.ProductDetailsListed);
            }
        }
    }
}
