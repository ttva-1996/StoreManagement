using MediatR;

using StoreManagement.Application.Dtos;


namespace StoreManagement.Application.Commands.Staffs.UpdateStaff
{
    public class UpdateStaffCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public UpdateAddressDto Address { get; set; }

        public UpdateStaffCommand(Guid id, string name, UpdateAddressDto address)
        {
            Id = id;
            Name = name;
            Address = address;
        }
    }
}
