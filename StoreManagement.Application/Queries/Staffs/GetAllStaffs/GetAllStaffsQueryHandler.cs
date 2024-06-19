using MediatR;

using Microsoft.EntityFrameworkCore;

using StoreManagement.Application.Dtos;
using StoreManagement.Domain.Interfaces;

namespace StoreManagement.Application.Queries.Staffs.GetAllStaffs
{
    public class GetAllStaffsQueryHandler : IRequestHandler<GetAllStaffsQuery, IEnumerable<GetAllStaffsQueryResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllStaffsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GetAllStaffsQueryResult>> Handle(GetAllStaffsQuery request, CancellationToken cancellationToken)
        {
            var query = _unitOfWork.Staffs
                .GetAll()
                .Include(s => s.Address).ThenInclude(s => s.Country)
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.SearchText))
            {
                query = query.Where(s => s.Name.Contains(request.SearchText));
            }

            var staffs = await query
                .Select(s => new GetAllStaffsQueryResult
                {
                    Id = s.Id,
                    Name = s.Name,
                    Address = s.Address == null ? null : new AddressDto
                    {
                        Detail = s.Address.Detail,
                        CountryId = s.Address.CountryId,
                        Country = s.Address.Country == null ? null : new CountryDto
                        {
                            Id = s.Address.Country.Id,
                            Name = s.Address.Country.Nicename,
                        }
                    }
                })
                .ToListAsync(cancellationToken);

            return staffs;
        }
    }
}
