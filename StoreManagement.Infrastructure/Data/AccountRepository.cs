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
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(StoreManagementDbContext dbContext) : base(dbContext) { }
    }
}
