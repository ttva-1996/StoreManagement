using RabbitMQ.Client;
using RabbitMQ.Client.Events;

using Shared;

using System.Text;
using System.Text.Json;

namespace QueryService
{
    public class EventSubscriber
    {
        private readonly IModel _channel;
        private readonly string _exchangeName = "order_exchange";

        public EventSubscriber()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
            _channel.ExchangeDeclare(exchange: _exchangeName, type: ExchangeType.Fanout);
        }

        public void SubscribeToOrderCreatedEvent()
        {
            var queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: queueName, exchange: _exchangeName, routingKey: "");

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var orderCreatedEvent = JsonSerializer.Deserialize<OrderCreatedEvent>(message);
                Console.WriteLine(" [x] Received {0}", message);
                HandleOrderCreatedEvent(orderCreatedEvent);
            };

            _channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }

        private void HandleOrderCreatedEvent(OrderCreatedEvent orderCreatedEvent)
        {
            // Here you would update the read database
            Console.WriteLine($"Order ID: {orderCreatedEvent.OrderId}, Amount: {orderCreatedEvent.TotalAmount}");
        }
    }
}
