using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Domain.Entities
{
    public class Account : BaseEntity
    {
        public Guid? StoreId { get; set; }

        [MaxLength(100)]
        public string? Username { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        [MaxLength(500)]
        public string? Password { get; set; }

        [MaxLength(250)]
        public string? FullName { get; set; }

        public string? PasswordHash { get; set; }

        public string? PasswordSalt { get; set; }
    }
}
