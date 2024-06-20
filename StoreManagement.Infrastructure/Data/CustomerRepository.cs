using StoreManagement.Domain.Entities;
using StoreManagement.Domain.Interfaces;

namespace StoreManagement.Infrastructure.Data
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(StoreManagementDbContext dbContext) : base(dbContext) { }
    }
}
