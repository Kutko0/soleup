using Microsoft.EntityFrameworkCore.Migrations;

namespace Soleup.API.Migrations
{
    public partial class UserDropNewField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WonItemId",
                table: "DropUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WonItemId",
                table: "DropUsers");
        }
    }
}
