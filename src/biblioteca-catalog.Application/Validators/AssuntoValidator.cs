using biblioteca_catalog.Application.Commands.Assunto.CreateAssunto;
using FluentValidation;

namespace biblioteca_catalog.Application.Validators
{
    public class AssuntoValidator : AbstractValidator<CreateAssuntoCommand>
    {
        public AssuntoValidator()
        {
            RuleFor(a => a.Descricao)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
