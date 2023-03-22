using API.ApiResponses;
using MediatR;
using System.Collections.Generic;

namespace API.Application.Queries
{
    public class SearchFlightsQuery : IRequest<IEnumerable<FlightResponse>>
    {
        public string Destination { get; set; }
    }
}
