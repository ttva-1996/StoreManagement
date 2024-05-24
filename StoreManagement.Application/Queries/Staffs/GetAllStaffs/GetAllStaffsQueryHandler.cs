using MediatR;

using StoreManagement.Domain.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var staffs = await _unitOfWork.Staffs.GetAllAsync();

            var response = staffs.Select(staff => new GetAllStaffsQueryResult
            {
                Id = staff.Id,
                Name = staff.Name,
            }).ToList();

            return response;
        }
    }
}
