using StoreManagement.Domain.Constants;

namespace StoreManagement.Application.Dtos
{
    public class UpdateAddressDto
    {
        public int? CountryId { get; set; } = DefaultConstants.DEFAULT_COUNTRY_VN;

        public string? Detail { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }
    }
}
