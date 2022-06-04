using AutoMapper;
using ETradeAPI.Application.Features.Products.Models;
using ETradeAPI.Application.Parameters;
using ETradeAPI.Application.Repositories.ProductRepository;
using ETradeAPI.Application.Wrappers.Paging;
using ETradeAPI.Application.Wrappers.Results.Abstract;
using ETradeAPI.Application.Wrappers.Results.Concrete;
using ETradeAPI.Domain.Constants;
using ETradeAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Products.Queries
{
    public class GetProductListQuery:IRequest<IDataResult<ProductListModel>>
    {
        public PageRequest RequestParameter { get; set; }
        public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, IDataResult<ProductListModel>>
        {
            private readonly IProductReadRepository _productReadRepository;
            private readonly IMapper _mapper;
            public GetProductListQueryHandler(IProductReadRepository productReadRepository,IMapper mapper)
            {
                _productReadRepository = productReadRepository;
                _mapper = mapper;
            }
            public async Task<IDataResult<ProductListModel>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
            {   
                IPaginate<Product> products = await _productReadRepository.GetListAsync(index:request.RequestParameter.Page, size:
                    request.RequestParameter.PageSize, cancellationToken: cancellationToken);
                ProductListModel model = _mapper.Map<ProductListModel>(products); 
                return new SuccessDataResult<ProductListModel>(model,Messages.ProductsListed);
;            }
        }
    }
}
