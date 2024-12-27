using FluentValidation;
using MyGoodStock.Api.Models.ViewModel;

namespace MyGoodStock.Api.Validators
{
    public class MonthlyProfitReportValidator : AbstractValidator<MonthlyProfitReportViewModel>
    {
        public MonthlyProfitReportValidator()
        {
            RuleFor(x => x.Month)
           .NotEmpty().WithMessage("O mês não pode ser vazio.")
           .LessThanOrEqualTo(DateTime.Now).WithMessage("O mês não pode estar no futuro.");

            RuleFor(x => x.TotalProfit)
                .GreaterThanOrEqualTo(0).WithMessage("O lucro total não pode ser negativo.");
        }
    }
}
