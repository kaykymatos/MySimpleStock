using FluentValidation;
using MySimpleStock.Api.Models.ViewModel;

namespace MySimpleStock.Api.Validators
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
