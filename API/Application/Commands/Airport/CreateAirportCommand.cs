using MediatR;

namespace API.Application.Commands.Airport
{
    public class CreateAirportCommand : IRequest<Domain.Aggregates.AirportAggregate.Airport>
    {
        public string Code { get; private set; }
        
        public string Name { get; private set; }

        public CreateAirportCommand(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}