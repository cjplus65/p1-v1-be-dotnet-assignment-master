﻿using Domain.Aggregates.FlightAggregate;
using Domain.SeedWork;
using System;

namespace Domain.Aggregates.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        public string PassengerEmail { get; set; }

        public Guid FlightId { get; set; }

        public Flight Flight { get; private set; }

        public OrderStatus Status { get; set; }

        public Guid FlightRateId { get; set; }

        public FlightRate FlightRate { get; private set; }

        public int NumberOfSeats { get; set; }
    }
}
