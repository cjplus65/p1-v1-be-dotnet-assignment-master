using Domain.Aggregates.FlightAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositores
{
    public class FlightRepository : Repository<Flight>, IFlightRepository
    {
        public FlightRepository(FlightsContext context):base(context)
        {
        }

        public async Task<List<Flight>> GetAvailableFlightsByAirportId(Guid destinationAirportId)
        {
            return await Context.Flights.Include(x => x.Rates)
                .Where(i => i.DestinationAirportId == destinationAirportId && i.Rates.Count > 0).ToListAsync();
        }

        public async Task<Flight> GetFlightWithFlightRates(Guid flightId)
        {
            return await Context.Flights.Include(x => x.Rates).FirstOrDefaultAsync(x => x.Id == flightId);
        }
    }
}
