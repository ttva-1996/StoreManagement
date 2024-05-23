using MediatR;

using StoreManagement.Domain.Entities;
using StoreManagement.Domain.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Application.Commands.Staffs.CreateStaff
{
    public class CreateStaffCommandHandler : IRequestHandler<CreateStaffCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateStaffCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreateStaffCommand request, CancellationToken cancellationToken)
        {
            var staff = new Staff()
            {
                Name = request.Name
            };

            await _unitOfWork.Staffs.AddAsync(staff);
            return true;
        }
    }
}
