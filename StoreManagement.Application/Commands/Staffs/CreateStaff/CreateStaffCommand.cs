using MediatR;

using StoreManagement.Application.Dtos;


namespace StoreManagement.Application.Commands.Staffs.CreateStaff
{
    public class CreateStaffCommand : IRequest<bool>
    {
        public string Name { get; set; }

        public UpdateAddressDto Address { get; set; }

        public CreateStaffCommand(string name, UpdateAddressDto address)
        {
            Name = name;
            Address = address;
        }
    }
}
