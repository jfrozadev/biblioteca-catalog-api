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

            // Adicione outras regras de validação conforme necessário para a criação de um Autor
        }
    }
}