﻿using Domain.Aggregates.OrderAggregate;
using Domain.Exceptions;
using Domain.SeedWork;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Aggregates.FlightAggregate;

namespace API.Application.Commands.Order
{
    public class ConfirmOrderCommandHandler : IRequestHandler<ConfirmOrderCommand, Domain.Aggregates.OrderAggregate.Order>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IFlightRepository _flightRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ConfirmOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IFlightRepository flightRepository)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _flightRepository = flightRepository;
        }
        public async Task<Domain.Aggregates.OrderAggregate.Order> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(request.OrderId);
            if (order == null)
            {
                throw new OrderDomainException("Order not available");
            }

            if (order.Status == OrderStatus.Confirmed)
                throw new OrderDomainException("This order is already confirmed.");

            var flight = await _flightRepository.GetFlightWithFlightRates(order.FlightId);
            
            //Did not added null check for flight assuming that at this point it should available.
            var flightRate = flight.Rates.First(x => x.Id == order.FlightRateId);
            if (flightRate.Available < order.NumberOfSeats)
            {
                throw new OrderDomainException($"Only {flightRate.Available} seats are available for this rate.");
            }

            flight.LowerRateAvailability(order.FlightRateId, flightRate.Available - order.NumberOfSeats);
            _flightRepository.Update(flight);

            order.Status = OrderStatus.Confirmed;
            _orderRepository.Update(order);
            await _unitOfWork.SaveEntitiesAsync(cancellationToken);
            Console.WriteLine($"Order Confirmed. Order Id {order.Id}");

            return order;
        }
    }
}
