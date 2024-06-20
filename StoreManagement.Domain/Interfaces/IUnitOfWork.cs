using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

        IStaffRepository Staffs { get; }

        IAccountRepository Accounts { get; }

        ICustomerRepository Customers { get; }
    }
}
