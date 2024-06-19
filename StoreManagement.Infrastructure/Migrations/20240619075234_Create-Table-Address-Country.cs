using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableAddressCountry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Store",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Staff",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Iso = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Nicename = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Iso3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Numcode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phonecode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CurrencyCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    LastSavedUser = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastSavedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUser = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Store_AddressId",
                table: "Store",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_AddressId",
                table: "Staff",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CountryId",
                table: "Address",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_IsDeleted",
                table: "Address",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Address_AddressId",
                table: "Staff",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Store_Address_AddressId",
                table: "Store",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Address_AddressId",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_Store_Address_AddressId",
                table: "Store");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Store_AddressId",
                table: "Store");

            migrationBuilder.DropIndex(
                name: "IX_Staff_AddressId",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Staff");
        }
    }
}
