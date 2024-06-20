using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using StoreManagement.Application.Commands.Customers.CreateCustomer;
using StoreManagement.Application.Commands.Customers.UpdateCustomer;
using StoreManagement.Application.Queries.Customers.GetAllCustomers;

namespace StoreManagement.WebApi.Controllers
{
    [Authorize]
    public class CustomerController : BaseApiController
    {
        public CustomerController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAllCustomersQueryResult>>> GetAllStaffs([FromQuery] GetAllCustomersQuery query)
        {
            var results = await _mediator.Send(query);
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] CreateCustomerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerAsync(Guid id, [FromBody] UpdateCustomerCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
