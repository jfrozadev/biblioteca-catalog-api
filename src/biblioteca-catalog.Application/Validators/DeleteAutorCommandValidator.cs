using FluentValidation;
using biblioteca_catalog.Application.Commands.Autor.DeleteAutor;

namespace biblioteca_catalog.Application.Validators
{
    public class DeleteAutorCommandValidator : AbstractValidator<DeleteAutorCommand>
    {
        public DeleteAutorCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}