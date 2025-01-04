using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgateProject.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampaignManagers_Campaigns_CampaignID",
                table: "CampaignManagers");

            migrationBuilder.DropIndex(
                name: "IX_CampaignManagers_CampaignID",
                table: "CampaignManagers");

            migrationBuilder.DropColumn(
                name: "CampaignID",
                table: "CampaignManagers");

            migrationBuilder.RenameColumn(
                name: "CampaingBudget",
                table: "Campaigns",
                newName: "CampaignBudget");

            migrationBuilder.AddColumn<string>(
                name: "CampaignManagerID",
                table: "Campaigns",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CampaignManagerID",
                table: "Campaigns");

            migrationBuilder.RenameColumn(
                name: "CampaignBudget",
                table: "Campaigns",
                newName: "CampaingBudget");

            migrationBuilder.AddColumn<int>(
                name: "CampaignID",
                table: "CampaignManagers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CampaignManagers_CampaignID",
                table: "CampaignManagers",
                column: "CampaignID");

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignManagers_Campaigns_CampaignID",
                table: "CampaignManagers",
                column: "CampaignID",
                principalTable: "Campaigns",
                principalColumn: "CampaignID");
        }
    }
}
