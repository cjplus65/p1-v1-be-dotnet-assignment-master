using API.Application.Commands.Order;
using FluentValidation;

namespace API.Application.Validators
{
    public class ConfirmOrderCommandValidator : AbstractValidator<ConfirmOrderCommand>
    {
        public ConfirmOrderCommandValidator()
        {
            RuleFor(c => c.OrderId).NotEmpty();
            RuleFor(c => c.Confirm).NotEmpty();
        }
    }
}
