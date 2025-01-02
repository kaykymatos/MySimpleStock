using FluentValidation;
using MySimpleStock.Api.Models.ViewModel;

namespace MySimpleStock.Api.Validators
{
    public class SaleItemValidator : AbstractValidator<SaleItemViewModel>
    {
        public SaleItemValidator()
        {
            RuleFor(x => x.SaleId).NotEmpty().WithMessage("O SaleId não pode ser vazio.");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("O ProductId não pode ser vazio.");
            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("A quantidade deve ser maior que zero.");
            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("O preço não pode ser negativo.");
        }
    }
}
