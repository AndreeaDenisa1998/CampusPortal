using Microsoft.EntityFrameworkCore.Migrations;

namespace Travelers.Persistence.Migrations
{
    public partial class Changes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_User_UserId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_User_UserId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_User_UserId",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Review",
                newName: "IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_Review_UserId",
                table: "Review",
                newName: "IX_Review_IdUser");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Post",
                newName: "IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_Post_UserId",
                table: "Post",
                newName: "IX_Post_IdUser");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comment",
                newName: "IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                newName: "IX_Comment_IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_User_IdUser",
                table: "Comment",
                column: "IdUser",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_User_IdUser",
                table: "Post",
                column: "IdUser",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_User_IdUser",
                table: "Review",
                column: "IdUser",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_User_IdUser",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_User_IdUser",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_User_IdUser",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Review",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_IdUser",
                table: "Review",
                newName: "IX_Review_UserId");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Post",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_IdUser",
                table: "Post",
                newName: "IX_Post_UserId");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Comment",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_IdUser",
                table: "Comment",
                newName: "IX_Comment_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_User_UserId",
                table: "Comment",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_User_UserId",
                table: "Post",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_User_UserId",
                table: "Review",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
