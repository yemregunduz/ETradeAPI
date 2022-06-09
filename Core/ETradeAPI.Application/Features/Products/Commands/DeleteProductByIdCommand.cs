using Common.Application.BusinessRules;
using Common.Application.Wrappers.Results.Abstract;
using Common.Application.Wrappers.Results.Concrete;
using ETradeAPI.Application.Features.Products.Rules;
using ETradeAPI.Application.Repositories.ProductRepository;

using ETradeAPI.Domain.Constants;
using MediatR;

namespace ETradeAPI.Application.Features.Products.Commands
{
    public class DeleteProductByIdCommand:IRequest<IResult>
    {
        public string Id { get; set; }
        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, IResult>
        {
            private readonly IProductWriteRepository _productWriteRepository;
            private readonly ProductBusinessRules _productBusinesRules;
            public DeleteProductByIdCommandHandler(IProductWriteRepository productWriteRepository, ProductBusinessRules productBusinesRules)
            {
                _productWriteRepository = productWriteRepository;
                _productBusinesRules = productBusinesRules;
            }
            public async Task<IResult> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
            {
                IResult result = BusinessRules.Run(await _productBusinesRules.CheckProductIsExist(request.Id));
                if (result != null)
                {
                    return result;
                }
                await _productWriteRepository.RemoveAsync(request.Id);
                return new SuccessResult(Messages.ProductDeleted);
            }
        }
    }
}
