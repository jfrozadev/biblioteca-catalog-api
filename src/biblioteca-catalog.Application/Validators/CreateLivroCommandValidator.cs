using FluentValidation;
using biblioteca_catalog.Application.Commands.Livro.CreateLivro;

namespace biblioteca_catalog.Application.Validators
{
    public class CreateLivroCommandValidator : AbstractValidator<CreateLivroCommand>
    {
        public CreateLivroCommandValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("O Título é obrigatório.");

            RuleFor(x => x.Editora)
                .NotEmpty().WithMessage("A Editora é obrigatória.");

            RuleFor(x => x.AnoPublicacao)
                .NotEmpty().WithMessage("O Ano de Publicação é obrigatório.");

            RuleFor(x => x.Edicao)
                .GreaterThan(0).WithMessage("A Edição deve ser um número positivo.");
        }
    }
}
