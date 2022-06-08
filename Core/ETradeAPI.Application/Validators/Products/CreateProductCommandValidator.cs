using ETradeAPI.Application.Features.Products.Commands;
using ETradeAPI.Domain.Constants;
using FluentValidation;

namespace ETradeAPI.Application.Validators.Products
{
    public class CreateProductCommandValidator:AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                    .WithMessage(Messages.ProductNameIsRequired)
                .Length(2,150)
                    .WithMessage(Messages.ProductNameIsInvalid);
            RuleFor(p => p.Stock)
                .NotNull()
                    .WithMessage(Messages.StockIsRequired)
                .GreaterThanOrEqualTo(0)
                    .WithMessage(Messages.StockIsInvalid);
            RuleFor(p => p.UnitPrice)
                .NotNull()
                    .WithMessage(Messages.UnitPriceIsRequired)
                .GreaterThan(0)
                    .WithMessage(Messages.UnitPriceIsInvalid);
                
        }
    }
}
