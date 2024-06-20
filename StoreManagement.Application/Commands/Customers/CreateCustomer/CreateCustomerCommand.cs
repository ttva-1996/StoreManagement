using MediatR;

using StoreManagement.Application.Dtos;

namespace StoreManagement.Application.Commands.Customers.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<bool>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public UpdateAddressDto Address { get; set; }

        public CreateCustomerCommand(
            string name, 
            string email,
            string phoneNumber,
            UpdateAddressDto address)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
        }
    }
}
