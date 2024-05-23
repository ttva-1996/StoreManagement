using StoreManagement.Domain.Entities;
using StoreManagement.Domain.Interfaces;

using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Infrastructure.Data
{
    public class StaffRepository : GenericRepository<Staff>, IStaffRepository
    {
        public StaffRepository(StoreManagementDbContext dbContext) : base(dbContext) { }
    }
}
