using MediatR;

using StoreManagement.Domain.Interfaces;

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
            try
            {
                var staff = await _unitOfWork.Staffs.GetStaffByIdAsync(request.Id) ?? throw new KeyNotFoundException("Staff not found");

                staff.Name = request.Name;

                if (request.Address != null)
                {
                    staff.Address.Detail = request.Address.Detail;
                    staff.Address.CountryId = request.Address.CountryId;
                }

                await _unitOfWork.Staffs.UpdateAsync(staff);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
