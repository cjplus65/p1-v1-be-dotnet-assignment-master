using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using Domain.Exceptions;
using Domain.SeedWork;

namespace API.Application.Commands.Order
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Domain.Aggregates.OrderAggregate.Order>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IFlightRepository _flightRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IFlightRepository flightRepository)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _flightRepository = flightRepository;
        }

        public async Task<Domain.Aggregates.OrderAggregate.Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var flight = await _flightRepository.GetAsync(request.FlightId);
            if (flight == null)
            {
                throw new FlightDomainException("Invalid Flight Id.");
            }

            var order = _orderRepository.Add(new Domain.Aggregates.OrderAggregate.Order
            {
                FlightId = request.FlightId,
                PassengerEmail = request.PassengerEmail,
                Status = OrderStatus.Draft,
                FlightRateId = request.FlightRateId
            });

            await _unitOfWork.SaveEntitiesAsync(cancellationToken);
            return order;
        }
    }
}
