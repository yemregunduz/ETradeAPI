using AutoMapper;
using ETradeAPI.Application.Features.Products.Dtos;
using ETradeAPI.Application.Repositories.ProductRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Products.Queries
{
    public class GetProductByIdQuery:IRequest<ProductListDto>
    {
        public string Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductListDto>
        {
            private readonly IProductReadRepository _productReadRepository;
            private readonly IMapper _mapper;
            public GetProductByIdQueryHandler(IProductReadRepository productReadRepository, IMapper mapper)
            {
                _productReadRepository = productReadRepository;
                _mapper = mapper;
            }
            public async Task<ProductListDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var product = await _productReadRepository.GetByIdAsync(request.Id);
                ProductListDto model = _mapper.Map<ProductListDto>(product);
                return model;
            }
        }
    }
}
