namespace CommandService
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventPublisher = new EventPublisher();
            var orderService = new OrderService(eventPublisher);

            orderService.CreateOrder(1, DateTime.Now, 100.50m);
            Console.WriteLine("Order Created and Event Published.");
        }
    }
}
