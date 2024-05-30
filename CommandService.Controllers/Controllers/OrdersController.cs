using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderCreateModel model)
        {
            _orderService.CreateOrder(model.OrderId, model.CreatedAt, model.TotalAmount);
            return Ok();
        }
    }

    public class OrderCreateModel
    {
        public int OrderId { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
