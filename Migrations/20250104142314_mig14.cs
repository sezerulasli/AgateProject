using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgateProject.Migrations
{
    /// <inheritdoc />
    public partial class mig14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completion",
                table: "Campaigns");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Completion",
                table: "Campaigns",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
