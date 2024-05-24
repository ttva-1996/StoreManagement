using MediatR;

using StoreManagement.Domain.Entities;
using StoreManagement.Domain.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Application.Commands.Staffs.UpdateStaff
{
    public class UpdateStaffCommandHandler : IRequestHandler<UpdateStaffCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStaffCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateStaffCommand request, CancellationToken cancellationToken)
        {
            var staff = await _unitOfWork.Staffs.GetByIdAsync(request.Id) ?? throw new KeyNotFoundException("Staff not found");

            staff.Name = request.Name;
            await _unitOfWork.Staffs.UpdateAsync(staff);

            return true;
        }
    }
}
