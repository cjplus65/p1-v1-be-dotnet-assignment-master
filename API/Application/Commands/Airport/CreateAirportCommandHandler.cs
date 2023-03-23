using Domain.Aggregates.AirportAggregate;
using Domain.SeedWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands.Airport
{
    public class CreateAirportCommandHandler : IRequestHandler<CreateAirportCommand, Domain.Aggregates.AirportAggregate.Airport>
    {
        private readonly IAirportRepository _airportRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateAirportCommandHandler(IAirportRepository airportRepository, IUnitOfWork unitOfWork)
        {
            _airportRepository = airportRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Domain.Aggregates.AirportAggregate.Airport> Handle(CreateAirportCommand request, CancellationToken cancellationToken)
        {
            var airport = _airportRepository.Add(new Domain.Aggregates.AirportAggregate.Airport(request.Code, request.Name));
            await _unitOfWork.SaveEntitiesAsync(cancellationToken);
            
            return airport;
        }
    }
}