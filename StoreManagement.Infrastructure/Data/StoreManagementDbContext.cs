using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Infrastructure.Data
{
    public class StoreManagementDbContext(DbContextOptions<StoreManagementDbContext> options) : DbContext(options)
    {
    }
}
