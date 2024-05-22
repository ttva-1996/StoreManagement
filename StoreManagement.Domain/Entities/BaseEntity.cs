using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StoreManagement.Domain.Entities
{
    [Index(nameof(IsDeleted), IsUnique = false)]
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public Guid? LastSavedUser { get; set; }

        public DateTime? LastSavedTime { get; set; }

        public Guid? CreatedUser { get; set; }

        public DateTime? CreatedTime { get; set; }

        public bool IsDeleted { get; set; }
    }
}
