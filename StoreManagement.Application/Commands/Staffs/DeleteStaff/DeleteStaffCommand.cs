using MediatR;

namespace StoreManagement.Application.Commands.Staffs.DeleteStaff
{
    public class DeleteStaffCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteStaffCommand(Guid id)
        {
            Id = id;
        }
    }
}
