using StoreManagement.Domain.Interfaces;

namespace StoreManagement.Infrastructure.Data
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

        public IStaffRepository Staffs { get { return _staffRepository ??= new StaffRepository(_context); } }
        public IAccountRepository Accounts { get { return _accountRepository ??= new AccountRepository(_context); } }

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
