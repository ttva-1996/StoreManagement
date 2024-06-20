IF OBJECT_ID('dbo.SP_GetAllCustomers', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_GetAllCustomers;
GO

CREATE PROCEDURE SP_GetAllCustomers
    @SearchText NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        c.Id AS CustomerId,
        c.Name AS CustomerName,
        c.Email,
        c.PhoneNumber,
        a.Detail AS AddressDetail,
        a.CountryId AS AddressCountryId,
        co.Id AS CountryId,
        co.Nicename AS CountryName
    FROM 
        Customer c
    LEFT JOIN 
        dbo.[Address] a ON c.AddressId = a.Id
    LEFT JOIN 
        Country co ON a.CountryId = co.Id
    WHERE 
        @SearchText IS NULL OR @SearchText = '' OR c.Name LIKE '%' + @SearchText + '%';
END
GO