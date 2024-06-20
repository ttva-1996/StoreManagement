using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCustomerStoredProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE SP_UpdateCustomer
                    @CustomerId UNIQUEIDENTIFIER,
                    @Name NVARCHAR(200),
                    @Email NVARCHAR(100),
                    @PhoneNumber NVARCHAR(50),
                    @AddressDetail NVARCHAR(255) = NULL,
                    @CountryId INT = NULL
                AS
                BEGIN
                    -- Check if the Customer exists
                    IF NOT EXISTS (SELECT 1 FROM Customer WHERE Id = @CustomerId)
                    BEGIN
                        RAISERROR('Customer not found', 16, 1);
                        RETURN;
                    END

                    -- Select table Customer
                    DECLARE @AddressId UNIQUEIDENTIFIER;
                    SELECT @AddressId = c.AddressId FROM Customer c WHERE c.Id = @CustomerId
	
                    -- Update the Customer's name
                    UPDATE Customer 
                    SET Name = @Name, Email = @Email, PhoneNumber = @PhoneNumber
                    WHERE Id = @CustomerId;

                    -- Update the address details if provided
                    IF @AddressDetail IS NOT NULL AND @CountryId IS NOT NULL
                    BEGIN
                        UPDATE Address
                        SET Detail = @AddressDetail,
                            CountryId = @CountryId
                        WHERE Id = @AddressId;
                    END
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE IF EXISTS SP_UpdateCustomer");
        }
    }
}
