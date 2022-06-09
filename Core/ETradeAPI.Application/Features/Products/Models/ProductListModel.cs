using Common.Application.Wrappers.Paging;
using ETradeAPI.Application.Features.Products.Dtos;

namespace ETradeAPI.Application.Features.Products.Models
{
    public class ProductListModel: BasePageableModel
    {
        public IList<ProductListDto> Items { get; set; }
    }
}
