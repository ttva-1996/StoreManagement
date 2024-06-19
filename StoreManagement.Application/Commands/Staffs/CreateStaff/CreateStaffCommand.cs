using MediatR;

using StoreManagement.Application.Dtos;


namespace StoreManagement.Application.Commands.Staffs.CreateStaff
{
    public class CreateStaffCommand : IRequest<bool>
    {
        public string Name { get; set; }

        public AddressDto Address { get; set; }

        public CreateStaffCommand(string name, AddressDto address)
        {
            Name = name;
            Address = address;
        }
    }
}
