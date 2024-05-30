using Microsoft.AspNetCore.Mvc;

using Shared;

namespace QueryService.Controller.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private static readonly List<OrderCreatedEvent> Orders = new List<OrderCreatedEvent>();

        [HttpGet]
        public IEnumerable<OrderCreatedEvent> GetOrders()
        {
            return Orders;
        }

        [HttpPost]
        public void AddOrder(OrderCreatedEvent order)
        {
            Orders.Add(order);
        }
    }
}
