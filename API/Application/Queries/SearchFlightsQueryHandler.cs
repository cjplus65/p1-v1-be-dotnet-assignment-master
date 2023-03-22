using API.ApiResponses;
using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.FlightAggregate;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Queries
{
    public class SearchFlightsQueryHandler : IRequestHandler<SearchFlightsQuery, IEnumerable<FlightResponse>>
    {
        private readonly IAirportRepository _airportRepository;
        private readonly IFlightRepository _flightRepository;

        public SearchFlightsQueryHandler(IAirportRepository airportRepository, IFlightRepository flightRepository)
        {
            _airportRepository = airportRepository;
            _flightRepository = flightRepository;
        }

        public async Task<IEnumerable<FlightResponse>> Handle(SearchFlightsQuery request, CancellationToken cancellationToken)
        {
            var destinationAirportName = request.Destination;
            if (string.IsNullOrEmpty(destinationAirportName))
                return null;

            var destinationAirport = await _airportRepository.SearchDestination(destinationAirportName);
            if (destinationAirport == null)
                return null;

            var availableFlights = await _flightRepository.GetAvailableFlightsByAirportId(destinationAirport.Id);
            if (availableFlights == null || !availableFlights.Any())
            {
                return null;
            }

            var flightResponses = new List<FlightResponse>();
            foreach (var availableFlight in availableFlights)
            {
                var departureAirport = await _airportRepository.GetAsync(availableFlight.OriginAirportId);
                var priceFrom = availableFlight.Rates.OrderBy(o => o.Price.Value).First().Price;
                flightResponses.Add(new FlightResponse(departureAirport.Code, destinationAirport.Code, availableFlight.Departure, availableFlight.Arrival, priceFrom.Value));
            }

            return flightResponses;

        }
    }
}
