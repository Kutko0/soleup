using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Soleup.API.Migrations
{
    public partial class PostTypeAndCommentPostChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Posts",
                newName: "TypeId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Posts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "PostTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTypes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostTypes");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Posts",
                newName: "Type");
        }
    }
}
