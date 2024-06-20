using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagement.Domain.Entities
{
    [Table(nameof(Customer))]
    public class Customer : BaseEntity
    {
        [MaxLength(200)]
        public string? Name { get; set; }

        [MaxLength(100)]
        public string? Email  { get; set; }

        [MaxLength(50)]
        public string? PhoneNumber { get; set; }

        public Guid? StoreId { get; set; }

        public Guid? AddressId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; } 

        public virtual Store? Store { get; set; }

        public virtual Address? Address { get; set; }
    }
}
