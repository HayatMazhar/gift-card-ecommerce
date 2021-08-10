using FluentValidation;

namespace Bamboo.Application.Features.Product.Commands
{
    public class CreateCommandValidator : AbstractValidator<CreateProductCommand>
    {
        
        public CreateCommandValidator()
        {
            RuleFor(d => d.Name)
                .NotEmpty().WithMessage("Name is required.")
                .NotNull();
        }

    }
}
