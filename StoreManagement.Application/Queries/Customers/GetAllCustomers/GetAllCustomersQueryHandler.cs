using MediatR;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using StoreManagement.Application.Dtos;
using StoreManagement.Application.Queries.Customers.GetAllCustomers;
using StoreManagement.Domain.Interfaces;

namespace StoreManagement.Application.Queriec.Customerc.GetAllCustomers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<GetAllCustomersQueryResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCustomersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GetAllCustomersQueryResult>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var searchTextParam = new SqlParameter("@SearchText", request.SearchText ?? (object)DBNull.Value);

            var customers = await _unitOfWork.Customers
                .FromSqlRaw("EXEC SP_GetAllCustomers @SearchText", searchTextParam)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            var result = customers.Select(c => new GetAllCustomersQueryResult
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                Address = c.Address == null ? null : new AddressDto
                {
                    Detail = c.Address.Detail,
                    CountryId = c.Address.CountryId,
                    Country = c.Address.Country == null ? null : new CountryDto
                    {
                        Id = c.Address.Country.Id,
                        Name = c.Address.Country.Nicename,
                    }
                }
            }).ToList();

            return result;
        }
    }
}
