using MediatR;

using Microsoft.EntityFrameworkCore;

using StoreManagement.Application.Dtos;
using StoreManagement.Domain.Interfaces;

namespace StoreManagement.Application.Queries.Staffs.GetStaff
{
    public class GetStaffQueryHandler : IRequestHandler<GetStaffQuery, GetStaffQueryResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetStaffQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetStaffQueryResult> Handle(GetStaffQuery request, CancellationToken cancellationToken)
        {
            var staff = await _unitOfWork.Staffs
                .Where(s => s.Id == request.Id)
                .Include(s => s.Address).ThenInclude(s => s.Country)
                .AsNoTracking()
                .Select(s => new GetStaffQueryResult
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
                }).FirstOrDefaultAsync(cancellationToken);

            if (staff == null)
            {
                return null;
            }

            return staff;
        }
    }
}
