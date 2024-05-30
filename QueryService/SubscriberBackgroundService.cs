using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryService
{
    public class SubscriberBackgroundService : BackgroundService
    {
        private readonly EventSubscriber _eventSubscriber;

        public SubscriberBackgroundService(EventSubscriber eventSubscriber)
        {
            _eventSubscriber = eventSubscriber;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(() => _eventSubscriber.SubscribeToOrderCreatedEvent(), stoppingToken);
        }
    }
}
