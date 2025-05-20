using FluentValidation;
using biblioteca_catalog.Application.Commands.Autor.UpdateAutor;

namespace biblioteca_catalog.Application.Validators
{
    public class UpdateAutorCommandValidator : AbstractValidator<UpdateAutorCommand>
    {
        public UpdateAutorCommandValidator()
        {
            RuleFor(a => a.Id)
                .NotEmpty().WithMessage("Id is required.");

            RuleFor(a => a.Nome)
                .NotEmpty().WithMessage("Nome is required.")
                .MaximumLength(100).WithMessage("Nome cannot exceed 100 characters.");

            // Add other validation rules for Autor properties as needed
        }
    }
}