using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgateProject.Migrations
{
    /// <inheritdoc />
    public partial class mig13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClientPassword",
                table: "Clients",
                newName: "CompletionState");

            migrationBuilder.AddColumn<DateOnly>(
                name: "CompletionDate",
                table: "Clients",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletionDate",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "CompletionState",
                table: "Clients",
                newName: "ClientPassword");
        }
    }
}
