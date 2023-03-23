using MediatR;
using System;

namespace API.Application.Commands.Order
{
    public class CreateOrderCommand : IRequest<Domain.Aggregates.OrderAggregate.Order>
    {
        public string PassengerEmail { get; set; }

        public Guid FlightId { get; set; }

        public Guid FlightRateId { get; set; }

        public int NumberOfSeats { get; set; }
    }
}
