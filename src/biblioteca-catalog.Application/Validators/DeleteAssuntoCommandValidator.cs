using FluentValidation;
using biblioteca_catalog.Application.Commands.Assunto.DeleteAssunto;

namespace biblioteca_catalog.Application.Validators
{
    public class DeleteAssuntoCommandValidator : AbstractValidator<DeleteAssuntoCommand>
    {
        public DeleteAssuntoCommandValidator()
        {
            RuleFor(a => a.Id)
                .NotEmpty().WithMessage("O Id do assunto é obrigatório.");
        }
    }
}