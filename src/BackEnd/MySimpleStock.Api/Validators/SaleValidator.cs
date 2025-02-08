using FluentValidation;
using MySimpleStock.Api.Models.ViewModel;

namespace MySimpleStock.Api.Validators
{
    public class SaleValidator : AbstractValidator<SaleViewModel>
    {
        public SaleValidator()
        {
            RuleFor(x => x.Date)
            .NotEmpty().WithMessage("A data da venda não pode ser vazia.")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("A data da venda não pode estar no futuro.");

            RuleFor(x => x.TotalValue)
                .GreaterThan(0).WithMessage("O valor total deve ser maior que zero.");

            RuleFor(x => x.ClientId)
                .NotEmpty().WithMessage("O clientId deve ser preenchido.");

        }
    }
}
