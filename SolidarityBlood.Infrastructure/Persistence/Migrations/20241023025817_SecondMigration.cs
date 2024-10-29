using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolidarityBlood.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReasonExclusion",
                table: "tb_Donor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "tb_Donor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ReasonCanceled",
                table: "tb_Donation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "tb_Donation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ReasonUnavailable",
                table: "tb_BloodStock",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "tb_BloodStock",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ReasonExclusion",
                table: "tb_Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "tb_Address",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReasonExclusion",
                table: "tb_Donor");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "tb_Donor");

            migrationBuilder.DropColumn(
                name: "ReasonCanceled",
                table: "tb_Donation");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "tb_Donation");

            migrationBuilder.DropColumn(
                name: "ReasonUnavailable",
                table: "tb_BloodStock");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "tb_BloodStock");

            migrationBuilder.DropColumn(
                name: "ReasonExclusion",
                table: "tb_Address");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "tb_Address");
        }
    }
}
