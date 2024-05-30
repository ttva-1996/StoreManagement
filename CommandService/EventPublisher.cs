using RabbitMQ.Client;

using Shared;

using System.Text;
using System.Text.Json;

namespace CommandService
{
    public class EventPublisher
    {
        private readonly IModel _channel;
        private readonly string _exchangeName = "order_exchange";

        public EventPublisher()
        {
            var factory = new ConnectionFactory() {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            };
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
            _channel.ExchangeDeclare(exchange: _exchangeName, type: ExchangeType.Fanout);
        }

        public void PublishOrderCreatedEvent(OrderCreatedEvent orderCreatedEvent)
        {
            var message = JsonSerializer.Serialize(orderCreatedEvent);
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: _exchangeName,
                                  routingKey: "",
                                  basicProperties: null,
                                  body: body);
            Console.WriteLine(" [x] Sent {0}", message);
        }
    }
}
