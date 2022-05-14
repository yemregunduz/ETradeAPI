using AutoMapper;
using ETradeAPI.Application.Repositories.ProductRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Products.Commands
{
    public class DeleteProductByIdCommand:IRequest<bool>
    {
        public string Id { get; set; }
        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, bool>
        {
            private readonly IProductWriteRepository _productWriteRepository;
            private readonly IMapper _mapper;
            public DeleteProductByIdCommandHandler(IProductWriteRepository productWriteRepository, IMapper mapper)
            {
                _productWriteRepository = productWriteRepository;
                _mapper = mapper;
            }
            public async Task<bool> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
            {
                var isDeleted = await _productWriteRepository.RemoveAsync(request.Id);
                return isDeleted;
            }
        }
    }
}
