using FluentValidation;

namespace Bamboo.Application.Features.Order.Commands
{
    public class CreateCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        
        public CreateCommandValidator()
        {
          
        }

    }
}
