using StoreManagement.Application.Dtos;

namespace StoreManagement.Application.Queries.Staffs.GetAllStaffs
{
    public class GetAllStaffsQueryResult
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public AddressDto Address { get; set; }
    }
}
