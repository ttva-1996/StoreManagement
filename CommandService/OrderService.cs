using Shared;

namespace CommandService
{
    public class OrderService
    {
        private readonly EventPublisher _eventPublisher;

        public OrderService(EventPublisher eventPublisher)
        {
            _eventPublisher = eventPublisher;
        }

        public void CreateOrder(int orderId, DateTime createdAt, decimal totalAmount)
        {
            // Here you would save the order to the write database
            // ...

            // Publish OrderCreatedEvent
            var orderCreatedEvent = new OrderCreatedEvent
            {
                OrderId = orderId,
                CreatedAt = createdAt,
                TotalAmount = totalAmount
            };

            _eventPublisher.PublishOrderCreatedEvent(orderCreatedEvent);
        }
    }
}
