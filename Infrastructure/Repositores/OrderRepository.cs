using Domain.Aggregates.OrderAggregate;

namespace Infrastructure.Repositores
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(FlightsContext context) : base(context)
        {
        }
    }
}
