// See httpsclass Program
using QueryService;

{
    static void Main(string[] args)
    {
        var subscriber = new EventSubscriber();
        subscriber.SubscribeToOrderCreatedEvent();
    }
}