using Common.Application.Wrappers.Results.Abstract;
using Common.Application.Wrappers.Results.Concrete;
using ETradeAPI.Application.Repositories.ProductRepository;
using ETradeAPI.Domain.Constants;


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
