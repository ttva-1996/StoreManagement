using Microsoft.EntityFrameworkCore;

using StoreManagement.Domain.Entities;
using StoreManagement.Domain.Interfaces;

namespace StoreManagement.Infrastructure.Data
{
    public class StaffRepository : GenericRepository<Staff>, IStaffRepository
    {
        public StaffRepository(StoreManagementDbContext dbContext) : base(dbContext) { }

        public Task<Staff> GetStaffByIdAsync(Guid id)
        {
            var staff = _dbSet
                .Include(s => s.Address)
                .FirstOrDefaultAsync(s => s.Id == id);

            return staff;
        }
    }
}
