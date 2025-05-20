using FluentValidation;
using biblioteca_catalog.Application.Commands.Assunto.CreateAssunto;

namespace biblioteca_catalog.Application.Validators
{
    public class CreateAssuntoCommandValidator : AbstractValidator<CreateAssuntoCommand>
    {
        public CreateAssuntoCommandValidator()
        {
            RuleFor(a => a.Descricao)
                .NotEmpty().WithMessage("A descrição do assunto é obrigatória.")
                .MaximumLength(100).WithMessage("A descrição do assunto não pode exceder 100 caracteres.");
        }
    }
}