using FluentValidation;
using biblioteca_catalog.Application.Commands.Assunto.UpdateAssunto;

namespace biblioteca_catalog.Application.Validators
{
    public class UpdateAssuntoCommandValidator : AbstractValidator<UpdateAssuntoCommand>
    {
        public UpdateAssuntoCommandValidator()
        {
            RuleFor(a => a.Id)
                .NotEmpty().WithMessage("O Id do Assunto é obrigatório.");

            RuleFor(a => a.Nome)
                .NotEmpty().WithMessage("O nome do Assunto é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do Assunto não pode exceder 100 caracteres.");
        }
    }
}