using MediatR;

using StoreManagement.Application.Dtos;

namespace StoreManagement.Application.Commands.Customers.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public UpdateAddressDto Address { get; set; }

        public UpdateCustomerCommand(
            Guid id,
            string name,
            UpdateAddressDto address,
            string email,
            string phoneNumber)
        {
            Id = id;
            Name = name;
            Address = address;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
