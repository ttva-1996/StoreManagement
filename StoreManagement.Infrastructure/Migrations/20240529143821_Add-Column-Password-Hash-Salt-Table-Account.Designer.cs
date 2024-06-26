﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreManagement.Infrastructure.Data;

#nullable disable

namespace StoreManagement.Infrastructure.Migrations
{
    [DbContext(typeof(StoreManagementDbContext))]
    [Migration("20240529143821_Add-Column-Password-Hash-Salt-Table-Account")]
    partial class AddColumnPasswordHashSaltTableAccount
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StoreManagement.Domain.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FullName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastSavedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastSavedUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("StoreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Username")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d2172b15-0cdd-47f6-a1a7-14c785619c58"),
                            IsDeleted = false,
                            PasswordHash = "JgZY6PJJPSfRhmdrIO50aG/N7kG6XoilBcPWIahOwtJi89sYBz9zzFkc50YOJ6sOXTyNUL9IiidRQRO2WWMB6w==",
                            PasswordSalt = "Xncgs1FlXqJfI6vJpks1k7swFZsPsAIZjI+fIipC7Pm3xdolin91AjSh118sGiZMEE/lYd4QNTIRNjHUK6bRawAilxV/a0pwFd2gOgVqjxrBEEo3MI56+5UXz7u2YSJzekpV9Xc14I6f/Vfz8mDW3QRDcMhj3Ud2JSCD0/6GdY0=",
                            Username = "testuser"
                        });
                });

            modelBuilder.Entity("StoreManagement.Domain.Entities.Staff", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastSavedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastSavedUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid?>("StoreId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("StoreId");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("StoreManagement.Domain.Entities.Store", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastSavedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastSavedUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Store");
                });

            modelBuilder.Entity("StoreManagement.Domain.Entities.Staff", b =>
                {
                    b.HasOne("StoreManagement.Domain.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");

                    b.HasOne("StoreManagement.Domain.Entities.Store", "Store")
                        .WithMany("Staffs")
                        .HasForeignKey("StoreId");

                    b.Navigation("Account");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("StoreManagement.Domain.Entities.Store", b =>
                {
                    b.Navigation("Staffs");
                });
#pragma warning restore 612, 618
        }
    }
}
