using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnPasswordHashSaltTableAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordSalt",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "CreatedTime", "CreatedUser", "FullName", "IsDeleted", "LastSavedTime", "LastSavedUser", "Password", "PasswordHash", "PasswordSalt", "StoreId", "Username" },
                values: new object[] { new Guid("d2172b15-0cdd-47f6-a1a7-14c785619c58"), null, null, null, false, null, null, null, "JgZY6PJJPSfRhmdrIO50aG/N7kG6XoilBcPWIahOwtJi89sYBz9zzFkc50YOJ6sOXTyNUL9IiidRQRO2WWMB6w==", "Xncgs1FlXqJfI6vJpks1k7swFZsPsAIZjI+fIipC7Pm3xdolin91AjSh118sGiZMEE/lYd4QNTIRNjHUK6bRawAilxV/a0pwFd2gOgVqjxrBEEo3MI56+5UXz7u2YSJzekpV9Xc14I6f/Vfz8mDW3QRDcMhj3Ud2JSCD0/6GdY0=", null, "testuser" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("d2172b15-0cdd-47f6-a1a7-14c785619c58"));

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Accounts");
        }
    }
}
