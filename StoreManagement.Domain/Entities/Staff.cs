using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagement.Domain.Entities
{
    [Table(nameof(Staff))]
    public class Staff : BaseEntity
    {
        [MaxLength(200)]
        public string? Name { get; set; }

        public Guid? StoreId { get; set; }

        public Guid? AddressId { get; set; }

        public Guid? AccountId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; } //Indexed column

        public virtual Store? Store { get; set; }

        public virtual Account? Account { get; set; }

        public virtual Address? Address { get; set; }
    }
}
