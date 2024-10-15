using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolidarityBlood.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_BloodStock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RHFactor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityMl = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_BloodStock", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Donor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    BloodTypes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RHFactor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Donor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Donor_tb_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "tb_Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_Donation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDonation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuantityMl = table.Column<int>(type: "int", nullable: false),
                    DonorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Donation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Donation_tb_Donor_DonorId",
                        column: x => x.DonorId,
                        principalTable: "tb_Donor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Donation_DonorId",
                table: "tb_Donation",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Donor_AddressId",
                table: "tb_Donor",
                column: "AddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_BloodStock");

            migrationBuilder.DropTable(
                name: "tb_Donation");

            migrationBuilder.DropTable(
                name: "tb_Donor");

            migrationBuilder.DropTable(
                name: "tb_Address");
        }
    }
}
