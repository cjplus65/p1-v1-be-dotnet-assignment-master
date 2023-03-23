using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.FlightAggregate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositores
{
    public class AirportRepository : Repository<Airport>, IAirportRepository
    {
        public AirportRepository(FlightsContext context):base(context)
        {
        }

        public async Task<Airport> SearchDestination(string destination)
        {
            var airport = await Context.Airports.FirstOrDefaultAsync(a => a.Name.ToLower().Contains(destination.ToLower()));
            return airport;
        }

        public async Task<IEnumerable<Flight>> GetAvailableFlightsForDestination(string destination)
        {
            var airport = await Context.Airports.FirstOrDefaultAsync(a => a.Name.ToLower().Contains(destination.ToLower()));
            if (airport != null)
            {
                var availableFlights = await Context.Flights.Include(x=>x.Rates).Where(f => f.DestinationAirportId == airport.Id && f.Rates.Count > 0).ToListAsync();
                return availableFlights;
            }

            return null;
        }
    }
}