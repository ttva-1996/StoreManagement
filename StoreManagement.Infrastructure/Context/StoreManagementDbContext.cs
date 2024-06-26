﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staff>()
                .HasOne(sc => sc.Store)
                .WithMany(s => s.Staffs);

            modelBuilder.Entity<Staff>()
                    .HasIndex(s => s.Code)
                    .IsUnique(true);

            modelBuilder.Entity<Customer>()
               .HasIndex(s => s.Code)
               .IsUnique(true);

            modelBuilder.Entity<Staff>().Property(s => s.Code).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            modelBuilder.Entity<Customer>().Property(s => s.Code).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
        }
    }
}
