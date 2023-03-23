using API.Application.Commands.Order;
using FluentValidation;

namespace API.Application.Validators
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(c => c.PassengerEmail).NotEmpty().EmailAddress();
            RuleFor(c => c.FlightId).NotEmpty();
            RuleFor(c => c.NumberOfSeats).NotEmpty().GreaterThan(0);
        }
    }
}
