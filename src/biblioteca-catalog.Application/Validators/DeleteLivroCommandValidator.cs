using FluentValidation;
using biblioteca_catalog.Application.Commands.Livro.DeleteLivro;

namespace biblioteca_catalog.Application.Validators
{
    public class DeleteLivroCommandValidator : AbstractValidator<DeleteLivroCommand>
    {
        public DeleteLivroCommandValidator()
        {
            RuleFor(x => x.Codl)
                .GreaterThan(0).WithMessage("O Código do Livro (Codl) deve ser maior que zero.");
        }
    }
}