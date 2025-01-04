using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgateProject.Migrations
{
    /// <inheritdoc />
    public partial class mig8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CampaignManagerID",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "CampaignID",
                table: "CampaignManagers");

            migrationBuilder.RenameColumn(
                name: "Payment",
                table: "Clients",
                newName: "ClientPayment");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Clients",
                newName: "ClientEmail");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Clients",
                newName: "ClientAddress");

            migrationBuilder.AddColumn<string>(
                name: "CampaignManagerEmail",
                table: "CampaignManagers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CampaignManagerEmail",
                table: "CampaignManagers");

            migrationBuilder.RenameColumn(
                name: "ClientPayment",
                table: "Clients",
                newName: "Payment");

            migrationBuilder.RenameColumn(
                name: "ClientEmail",
                table: "Clients",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "ClientAddress",
                table: "Clients",
                newName: "Address");

            migrationBuilder.AddColumn<int>(
                name: "CampaignManagerID",
                table: "Campaigns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CampaignID",
                table: "CampaignManagers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
