using MediatR;

using StoreManagement.Domain.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Application.Commands.Staffs.DeleteStaff
{
    public class DeleteStaffCommandHandler : IRequestHandler<DeleteStaffCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteStaffCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteStaffCommand request, CancellationToken cancellationToken)
        {
            var staff = await _unitOfWork.Staffs.GetByIdAsync(request.Id) ?? throw new KeyNotFoundException("Staff not found");

            await _unitOfWork.Staffs.DeleteAsync(staff);

            return true;
        }
    }
}
