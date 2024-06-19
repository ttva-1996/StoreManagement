using MediatR;

using Microsoft.EntityFrameworkCore;

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
            var query = _unitOfWork.Staffs
                .GetAll()
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
                })
                .ToListAsync(cancellationToken);

            return staffs;
        }
    }
}
