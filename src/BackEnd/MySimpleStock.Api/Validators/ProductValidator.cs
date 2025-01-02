using FluentValidation;
using MySimpleStock.Api.Models.ViewModel;

namespace MySimpleStock.Api.Validators
{
    public class ProductValidator : AbstractValidator<ProductViewModel>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
           .NotEmpty().WithMessage("O nome do produto não pode ser vazio.")
           .MaximumLength(100).WithMessage("O nome do produto não pode ter mais de 100 caracteres.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("A descrição não pode ser vazia.")
                .MaximumLength(500).WithMessage("A descrição não pode ter mais de 500 caracteres.");

            RuleFor(x => x.CostPrice)
                .GreaterThanOrEqualTo(0).WithMessage("O preço de custo não pode ser negativo.");

            RuleFor(x => x.SalePrice)
                .GreaterThanOrEqualTo(0).WithMessage("O preço de venda não pode ser negativo.")
                .GreaterThan(x => x.CostPrice).WithMessage("O preço de venda deve ser maior que o preço de custo.");

            RuleFor(x => x.QuantityInStock)
                .GreaterThanOrEqualTo(0).WithMessage("A quantidade em estoque não pode ser negativa.");
        }
    }
}
