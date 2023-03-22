using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Aggregates.FlightAggregate;
using Domain.SeedWork;

namespace Domain.Aggregates.AirportAggregate
{
    public interface IAirportRepository : IRepository<Airport>
    {
        Task<IEnumerable<Flight>> GetAvailableFlightsForDestination(string destination);
        Task<Airport> SearchDestination(string destination);
    }
}