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
    }
}
