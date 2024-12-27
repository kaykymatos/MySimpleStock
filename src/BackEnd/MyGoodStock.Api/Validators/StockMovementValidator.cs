using FluentValidation;
using MyGoodStock.Api.Models.ViewModel;

namespace MyGoodStock.Api.Validators
{
    public class StockMovementValidator : AbstractValidator<StockMovementViewModel>
    {
        public StockMovementValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("O ProductId não pode ser vazio.");
            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("A quantidade não pode ser vazia.")
                .GreaterThanOrEqualTo(0).WithMessage("A quantidade não pode ser negativa.");
            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("A data não pode ser vazia.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data não pode estar no futuro.");
            RuleFor(x => x.MovementType)
                .NotEmpty().WithMessage("O tipo de movimento não pode ser vazio.")
                .Must(x => x == "Entrada" || x == "Saída")
                .WithMessage("O tipo de movimento deve ser 'Entrada' ou 'Saída'.");
        }
    }
}
