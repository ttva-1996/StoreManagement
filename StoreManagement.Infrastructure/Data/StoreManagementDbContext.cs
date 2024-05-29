using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using StoreManagement.Domain.Entities;
using StoreManagement.Domain.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Infrastructure.Data
{
    public class StoreManagementDbContext(DbContextOptions<StoreManagementDbContext> options) : DbContext(options)
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staff>()
                .HasOne(sc => sc.Store)
                .WithMany(s => s.Staffs);

            // Seeding initial user
            PasswordHasher.CreatePasswordHash("password", out string passwordHash, out string passwordSalt);
            modelBuilder.Entity<Account>().HasData(new Account
            {
                Id = new Guid("D2172B15-0CDD-47F6-A1A7-14C785619C58"),
                Username = "testuser",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            });
        }
    }
}
