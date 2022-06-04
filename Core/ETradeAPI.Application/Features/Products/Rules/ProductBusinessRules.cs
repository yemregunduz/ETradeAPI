using ETradeAPI.Application.Repositories.ProductRepository;
using ETradeAPI.Application.Wrappers.Results.Abstract;
using ETradeAPI.Application.Wrappers.Results.Concrete;
using ETradeAPI.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Products.Rules
{
    public class ProductBusinessRules
    {
        IProductReadRepository _productReadRepository;
        public ProductBusinessRules(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }
        public async Task<IResult> CheckProductIsExist(string productId)
        {
            var result = await _productReadRepository.GetByIdAsync(productId,false);
            if (result != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.ProductNotFound);
        }
    }
}
