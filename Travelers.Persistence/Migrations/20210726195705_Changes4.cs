using Microsoft.EntityFrameworkCore.Migrations;

namespace Travelers.Persistence.Migrations
{
    public partial class Changes4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Post_PostId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_Post_PostId",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Post_PostId",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_PostId",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Review",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdPosts",
                table: "Post",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Notification",
                newName: "IdPosts");

            migrationBuilder.RenameColumn(
                name: "IdNotification",
                table: "Notification",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Notification_PostId",
                table: "Notification",
                newName: "IX_Notification_IdPosts");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Comment",
                newName: "IdPosts");

            migrationBuilder.RenameColumn(
                name: "IdComments",
                table: "Comment",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_PostId",
                table: "Comment",
                newName: "IX_Comment_IdPosts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Review_IdPosts",
                table: "Review",
                column: "IdPosts");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Post_IdPosts",
                table: "Comment",
                column: "IdPosts",
                principalTable: "Post",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Post_IdPosts",
                table: "Notification",
                column: "IdPosts",
                principalTable: "Post",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Post_IdPosts",
                table: "Review",
                column: "IdPosts",
                principalTable: "Post",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Post_IdPosts",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_Post_IdPosts",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Post_IdPosts",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_IdPosts",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Review",
                newName: "PostId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Post",
                newName: "IdPosts");

            migrationBuilder.RenameColumn(
                name: "IdPosts",
                table: "Notification",
                newName: "PostId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Notification",
                newName: "IdNotification");

            migrationBuilder.RenameIndex(
                name: "IX_Notification_IdPosts",
                table: "Notification",
                newName: "IX_Notification_PostId");

            migrationBuilder.RenameColumn(
                name: "IdPosts",
                table: "Comment",
                newName: "PostId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comment",
                newName: "IdComments");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_IdPosts",
                table: "Comment",
                newName: "IX_Comment_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "IdPosts");

            migrationBuilder.CreateIndex(
                name: "IX_Review_PostId",
                table: "Review",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Post_PostId",
                table: "Comment",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "IdPosts");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Post_PostId",
                table: "Notification",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "IdPosts");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Post_PostId",
                table: "Review",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "IdPosts");
        }
    }
}
