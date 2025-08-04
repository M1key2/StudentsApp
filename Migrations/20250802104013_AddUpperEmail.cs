using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentsApp.Migrations
{
    /// <inheritdoc />
    public partial class AddUpperEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "email",
                table: "Emails",
                newName: "Mail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Mail",
                table: "Emails",
                newName: "email");
        }
    }
}
