using FluentValidation;
using biblioteca_catalog.Application.Commands.Autor.CreateAutor;

namespace biblioteca_catalog.Application.Validators
{
    public class CreateAutorCommandValidator : AbstractValidator<CreateAutorCommand>
    {
        public CreateAutorCommandValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(100).WithMessage("O nome não pode exceder 100 caracteres.");

            RuleFor(c => c.Sobrenome)
                .NotEmpty().WithMessage("O sobrenome é obrigatório.")
                .MaximumLength(100).WithMessage("O sobrenome não pode exceder 100 caracteres.");
        }
    }
}
