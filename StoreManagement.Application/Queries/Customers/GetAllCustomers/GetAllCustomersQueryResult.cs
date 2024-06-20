using StoreManagement.Application.Dtos;

namespace StoreManagement.Application.Queries.Customers.GetAllCustomers
{
    public class GetAllCustomersQueryResult
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public AddressDto Address { get; set; }
    }
}
