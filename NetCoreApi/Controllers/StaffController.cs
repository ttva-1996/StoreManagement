using MediatR;

using Microsoft.AspNetCore.Mvc;

using StoreManagement.Application.Commands.Staffs.CreateStaff;
using StoreManagement.Application.Commands.Staffs.DeleteStaff;
using StoreManagement.Application.Commands.Staffs.UpdateStaff;
using StoreManagement.Application.Queries.Staffs.GetAllStaffs;
using StoreManagement.Application.Queries.Staffs.GetStaff;

namespace StoreManagement.WebApi.Controllers
{
    public class StaffController : BaseApiController
    {
        public StaffController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAllStaffsQueryResult>>> GetAllStaffs()
        {
            var results = await _mediator.Send(new GetAllStaffsQuery());
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetStaffQueryResult>> GetStaffById(Guid id)
        {
            var result = await _mediator.Send(new GetStaffQuery(id));
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStaffAsync([FromBody] CreateStaffCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStaffAsync(Guid id, [FromBody] UpdateStaffCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStaffAsync(Guid id)
        {
            var result = await _mediator.Send(new DeleteStaffCommand(id));
            return Ok(result);
        }
    }
}
