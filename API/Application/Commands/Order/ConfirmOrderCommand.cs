using System;
using MediatR;

namespace API.Application.Commands.Order
{
    public class ConfirmOrderCommand : IRequest<Domain.Aggregates.OrderAggregate.Order>
    {
        public Guid OrderId { get; set; }

        public bool Confirm { get; set; }
    }
}
