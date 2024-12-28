using FluentValidation;
using MyGoodStock.Api.Models.ViewModel;

namespace MyGoodStock.Api.Validators
{
    public class MonthlyProfitReportValidator : AbstractValidator<MonthlyProfitReportViewModel>
    {
        public MonthlyProfitReportValidator()
        {

            RuleFor(x => x.TotalProfit)
                .GreaterThanOrEqualTo(0).WithMessage("O lucro total não pode ser negativo.");
        }
    }
}
