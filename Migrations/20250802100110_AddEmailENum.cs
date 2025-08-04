using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentsApp.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailENum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailTypeId",
                table: "Emails",
                newName: "EmailType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailType",
                table: "Emails",
                newName: "EmailTypeId");
        }
    }
}
