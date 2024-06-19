using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagement.Domain.Entities
{
    [Table(nameof(Address))]
    public class Address : BaseEntity
    {
        public int? CountryId { get; set; }

        [MaxLength(255)]
        public string? Detail { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public virtual Country? Country { get; set; }
    }
}
