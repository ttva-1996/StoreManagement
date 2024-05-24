using MediatR;

namespace StoreManagement.Application.Queries.Staffs.GetStaff
{
    public class GetStaffQuery : IRequest<GetStaffQueryResult>
    {
        public Guid Id { get; set; }

        public GetStaffQuery(Guid id)
        {
            Id = id;
        }
    }
}
