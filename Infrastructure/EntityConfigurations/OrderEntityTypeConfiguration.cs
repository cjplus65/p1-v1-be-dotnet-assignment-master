using Domain.Aggregates.OrderAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations
{
    internal class OrderEntityTypeConfiguration : BaseEntityTypeConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);
            builder.Property(i => i.PassengerEmail).IsRequired();
            builder.Property(i => i.NumberOfSeats).IsRequired();
            builder.HasOne(x=>x.Flight);
            builder.HasOne(x => x.FlightRate);
        }
    }
}
