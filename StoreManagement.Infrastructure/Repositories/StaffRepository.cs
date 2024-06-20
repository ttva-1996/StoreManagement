using Microsoft.EntityFrameworkCore;
using StoreManagement.Domain.Entities;
using StoreManagement.Domain.Interfaces;
using StoreManagement.Infrastructure.Data;

namespace StoreManagement.Infrastructure.Repositories
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
