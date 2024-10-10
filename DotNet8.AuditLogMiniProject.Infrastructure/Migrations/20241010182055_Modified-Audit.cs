using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNet8.AuditLogMiniProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedAudit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EntityName",
                table: "Tbl_Audit",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Operation",
                table: "Tbl_Audit",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntityName",
                table: "Tbl_Audit");

            migrationBuilder.DropColumn(
                name: "Operation",
                table: "Tbl_Audit");
        }
    }
}
