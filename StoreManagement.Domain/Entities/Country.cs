using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagement.Domain.Entities
{
    [Table(nameof(Country))]
    public class Country 
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string? Iso { get; set; }

        [MaxLength(100)]
        public string? Name { get; set; }

        [MaxLength(100)]
        public string? Nicename { get; set; }

        [MaxLength(100)]
        public string? Iso3 { get; set; }

        [MaxLength(100)]
        public string? Numcode { get; set; }

        [MaxLength(100)]
        public string? Phonecode { get; set; }

        [MaxLength(3)]
        public string? CurrencyCode { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
