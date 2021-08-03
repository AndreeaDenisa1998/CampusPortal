using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Travelers.Persistence.Migrations
{
    public partial class Changes3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationUser");

            migrationBuilder.AddColumn<Guid>(
                name: "IdUser",
                table: "Notification",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Notification_IdUser",
                table: "Notification",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_User_IdUser",
                table: "Notification",
                column: "IdUser",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_User_IdUser",
                table: "Notification");

            migrationBuilder.DropIndex(
                name: "IX_Notification_IdUser",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Notification");

            migrationBuilder.CreateTable(
                name: "NotificationUser",
                columns: table => new
                {
                    NotificationsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationUser", x => new { x.NotificationsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_NotificationUser_Notification_NotificationsId",
                        column: x => x.NotificationsId,
                        principalTable: "Notification",
                        principalColumn: "IdNotification",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotificationUser_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationUser_UsersId",
                table: "NotificationUser",
                column: "UsersId");
        }
    }
}
