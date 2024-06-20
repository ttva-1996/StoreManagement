using StoreManagement.Domain.Interfaces;
using StoreManagement.Infrastructure.Data;

namespace StoreManagement.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreManagementDbContext _context;

        public UnitOfWork(StoreManagementDbContext context)
        {
            _context = context;
        }

        private IStaffRepository _staffRepository;
        private IAccountRepository _accountRepository;
        private ICustomerRepository _customerRepository;

        public IStaffRepository Staffs { get { return _staffRepository ??= new StaffRepository(_context); } }
        public IAccountRepository Accounts { get { return _accountRepository ??= new AccountRepository(_context); } }
        public ICustomerRepository Customers { get { return _customerRepository ??= new CustomerRepository(_context); } }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
