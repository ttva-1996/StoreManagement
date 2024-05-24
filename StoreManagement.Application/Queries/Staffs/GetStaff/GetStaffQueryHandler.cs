using MediatR;

using StoreManagement.Domain.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var staff = await _unitOfWork.Staffs.GetByIdAsync(request.Id);
            if (staff == null)
            {
                return null;
            }

            var response = new GetStaffQueryResult
            {
                Id = staff.Id,
                Name = staff.Name
            };

            return response;
        }
    }
}
