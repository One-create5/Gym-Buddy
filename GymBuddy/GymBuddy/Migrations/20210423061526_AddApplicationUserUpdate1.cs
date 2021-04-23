using Microsoft.EntityFrameworkCore.Migrations;

namespace GymBuddy.Migrations
{
    public partial class AddApplicationUserUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "MaxLifts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaxLifts_ApplicationUserId",
                table: "MaxLifts",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_MaxLifts_AspNetUsers_ApplicationUserId",
                table: "MaxLifts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaxLifts_AspNetUsers_ApplicationUserId",
                table: "MaxLifts");

            migrationBuilder.DropIndex(
                name: "IX_MaxLifts_ApplicationUserId",
                table: "MaxLifts");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "MaxLifts");
        }
    }
}
