using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Domain.Entities
{
    [Table(nameof(Store))]
    public class Store : BaseEntity
    {
        [MaxLength(200)]
        public string? Name { get; set; }

        public Guid? AddressId { get; set; }

        public virtual Address? Address { get; set; }

        public virtual ICollection<Staff>? Staffs { get; set; }
    }
}
