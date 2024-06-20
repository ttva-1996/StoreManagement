using MediatR;

using Microsoft.Data.SqlClient;

using StoreManagement.Domain.Interfaces;

namespace StoreManagement.Application.Commands.Customers.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var sql = @"
                    DECLARE @addressId UNIQUEIDENTIFIER; 
                    SET @addressId = NEWID();

                    INSERT INTO Address (Id, CountryId, Detail, IsDeleted)
                    VALUES (@addressId, @CountryId, @Detail, 0);

                    DECLARE @customerId UNIQUEIDENTIFIER; 
                    SET @customerId = NEWID();

                    INSERT INTO Customer (Id, Name, Email, PhoneNumber, AddressId, IsDeleted)
                    VALUES (@customerId, @Name, @Email, @PhoneNumber, @addressId, 0);";

                var parameters = new[]
                {
                    new SqlParameter("@Name", request.Name),
                    new SqlParameter("@Email", request.Email),
                    new SqlParameter("@PhoneNumber", request.PhoneNumber),
                    new SqlParameter("@CountryId", request.Address.CountryId),
                    new SqlParameter("@Detail", request.Address.Detail)
                };

                await _unitOfWork.Customers.ExecuteSqlRawAsync(sql, parameters);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating customer.", ex);
            }
        }
    }
}
