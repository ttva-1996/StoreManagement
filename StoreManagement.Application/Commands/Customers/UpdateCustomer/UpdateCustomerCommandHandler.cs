using MediatR;

using Microsoft.Data.SqlClient;

using StoreManagement.Domain.Interfaces;

namespace StoreManagement.Application.Commands.Customers.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customerId = request.Id;
                var name = request.Name;
                var email = request.Email;
                var phoneNumber = request.PhoneNumber;
                var addressDetail = request.Address?.Detail;
                var countryId = request.Address?.CountryId;

                // Formulate the SQL command
                var sql = "EXEC SP_UpdateCustomer @CustomerId, @Name, @Email, @PhoneNumber, @AddressDetail, @CountryId";

                // Execute the command with parameters
                await _unitOfWork.Customers.ExecuteSqlRawAsync(
                    sql,
                    new SqlParameter("@CustomerId", customerId),
                    new SqlParameter("@Name", name),
                    new SqlParameter("@Email", email),
                    new SqlParameter("@PhoneNumber", phoneNumber),
                    new SqlParameter("@AddressDetail", addressDetail),
                    new SqlParameter("@CountryId", countryId)
                );

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating customer.", ex);
            }
        }
    }
}
