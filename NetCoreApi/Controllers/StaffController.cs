using MediatR;

using Microsoft.AspNetCore.Mvc;

using StoreManagement.Application.Commands.Staffs.CreateStaff;

namespace StoreManagement.WebApi.Controllers
{
    public class StaffController : BaseApiController
    {
        public StaffController(IMediator mediator) : base(mediator)
        {
        }


        [HttpPost]
        public async Task<IActionResult> CreateStaffAsync([FromBody] CreateStaffCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
