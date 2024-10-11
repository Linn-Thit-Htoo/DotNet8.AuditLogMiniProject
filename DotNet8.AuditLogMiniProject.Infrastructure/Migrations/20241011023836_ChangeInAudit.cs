using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNet8.AuditLogMiniProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeInAudit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Tbl_Audit",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Tbl_Audit");
        }
    }
}
