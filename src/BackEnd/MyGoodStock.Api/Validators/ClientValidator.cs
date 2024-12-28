using FluentValidation;
using MyGoodStock.Api.Models.ViewModel;

namespace MyGoodStock.Api.Validators
{
    public class ClientValidator : AbstractValidator<ClientViewModel>
    {
        public ClientValidator()
        {
            RuleFor(x => x.Name)
           .NotEmpty().WithMessage("O nome não pode ser vazio.")
           .MaximumLength(250).WithMessage("O nome não pode ter mais de 250 caracteres.");

            RuleFor(x => x.Address)
           .NotEmpty().WithMessage("O Endereço não pode ser vazio.")
           .MaximumLength(250).WithMessage("O Endereço não pode ter mais de 250 caracteres.");

            RuleFor(x => x.Cep)
          .NotEmpty().WithMessage("O cep não pode ser vazio.")
          .MaximumLength(20).WithMessage("O cep não pode ter mais de 100 caracteres.");

            RuleFor(x => x.Number)
          .NotEmpty().WithMessage("O número não pode ser vazio.")
          .MaximumLength(20).WithMessage("O número não pode ter mais de 100 caracteres.");
        }
    }
}
