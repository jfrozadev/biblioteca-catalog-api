csharp
using FluentValidation;
using biblioteca_catalog.Application.Commands.Livro.UpdateLivro;

namespace biblioteca_catalog.Application.Validators
{
    public class UpdateLivroCommandValidator : AbstractValidator<UpdateLivroCommand>
    {
        public UpdateLivroCommandValidator()
        {
            RuleFor(x => x.Codl)
                .GreaterThan(0).WithMessage("O código do livro (Codl) deve ser maior que zero.");

            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("O Título do livro não pode ser vazio.");

            RuleFor(x => x.Editora)
                .NotEmpty().WithMessage("A Editora do livro não pode ser vazia.");

            RuleFor(x => x.AnoPublicacao)
                .NotEmpty().WithMessage("O Ano de Publicação do livro não pode ser vazio.");
        }
    }
}