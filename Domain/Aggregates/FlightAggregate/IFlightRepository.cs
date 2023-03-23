using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.SeedWork;

namespace Domain.Aggregates.FlightAggregate
{
    public interface IFlightRepository:IRepository<Flight>
    {
        Task<List<Flight>> GetAvailableFlightsByAirportId(Guid destinationAirportId);

        Task<Flight> GetFlightWithFlightRates(Guid flightId);
    }
}