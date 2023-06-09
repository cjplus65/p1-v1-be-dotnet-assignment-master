using API.Application.Commands;
using API.Application.Commands.Airport;
using FluentValidation;

namespace API.Application.Validators
{
    public class CreateAirportCommandValidator : AbstractValidator<CreateAirportCommand>
    {
        public CreateAirportCommandValidator()
        {
            RuleFor(c => c.Code).NotEmpty().Length(3);
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}