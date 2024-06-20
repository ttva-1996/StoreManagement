using MediatR;

namespace StoreManagement.Application.Queries.Customers.GetAllCustomers
{
    public class GetAllCustomersQuery : IRequest<IEnumerable<GetAllCustomersQueryResult>>
    {
        public string? SearchText { get; set; }
    }
}
