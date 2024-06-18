using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Domain.Entities
{
    [Table(nameof(Staff))]
    public class Staff : BaseEntity
    {
        [MaxLength(200)]
        public string? Name { get; set; }

        public Guid? StoreId { get; set; }

        public Guid? AccountId { get; set; }

        public int? Code { get; set; } //Indexed column

        public virtual Store? Store { get; set; }

        public virtual Account? Account { get; set; }
    }
}
