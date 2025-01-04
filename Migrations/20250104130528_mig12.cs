using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgateProject.Migrations
{
    /// <inheritdoc />
    public partial class mig12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StaffEmail",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StaffPassword",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StaffContactEmail",
                table: "StaffContacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StaffContactPassword",
                table: "StaffContacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "CampaignBudget",
                table: "Campaigns",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StaffEmail",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "StaffPassword",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "StaffContactEmail",
                table: "StaffContacts");

            migrationBuilder.DropColumn(
                name: "StaffContactPassword",
                table: "StaffContacts");

            migrationBuilder.AlterColumn<double>(
                name: "CampaignBudget",
                table: "Campaigns",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
