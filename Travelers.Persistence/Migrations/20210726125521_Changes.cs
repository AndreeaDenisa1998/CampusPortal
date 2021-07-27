using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Travelers.Persistence.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Post");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Post",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
