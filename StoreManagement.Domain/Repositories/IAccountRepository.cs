using StoreManagement.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Domain.Interfaces
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
    }
}
