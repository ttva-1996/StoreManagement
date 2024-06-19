using MediatR;

using StoreManagement.Domain.Entities;
using StoreManagement.Domain.Interfaces;

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
            try
            {
                var staff = new Staff
                {
                    Name = request.Name,
                    Address = new Address
                    {
                        CountryId = request.Address.CountryId,
                        Detail = request.Address.Detail,
                    }
                };

                await _unitOfWork.Staffs.AddAsync(staff);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
