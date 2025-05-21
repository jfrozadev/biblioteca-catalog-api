using biblioteca_catalog.Application.Commands.Livro.CreateLivro;
using FluentValidation;

namespace biblioteca_catalog.Application.Validators
{
    public class LivroValidator : AbstractValidator<CreateLivroCommand>
    {
        public LivroValidator()
        {
            RuleFor(l => l.Titulo)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(l => l.Edicao)
                .GreaterThan(0);

            RuleFor(l => l.Ano)
                .GreaterThanOrEqualTo(1900)
                .LessThanOrEqualTo(DateTime.Now.Year);
        }
    }
}
