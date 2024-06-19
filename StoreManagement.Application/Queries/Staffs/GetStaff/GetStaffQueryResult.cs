using StoreManagement.Application.Dtos;

namespace StoreManagement.Application.Queries.Staffs.GetStaff
{
    public class GetStaffQueryResult
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public AddressDto Address { get; set; }
    }
}
