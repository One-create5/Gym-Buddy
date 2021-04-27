using Microsoft.EntityFrameworkCore.Migrations;

namespace GymBuddy.Migrations
{
    public partial class UpdateTables6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AspNetUsers_ApplicationUserId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_MaxLifts_ApplicationUserId",
                table: "MaxLifts");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ApplicationUserId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "UserWorkouts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MaxBench",
                table: "UserWorkouts",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MaxDeadLift",
                table: "UserWorkouts",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MaxSquat",
                table: "UserWorkouts",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "UserWorkouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkouts_ApplicationUserId",
                table: "UserWorkouts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MaxLifts_ApplicationUserId",
                table: "MaxLifts",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserWorkouts_AspNetUsers_ApplicationUserId",
                table: "UserWorkouts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWorkouts_AspNetUsers_ApplicationUserId",
                table: "UserWorkouts");

            migrationBuilder.DropIndex(
                name: "IX_UserWorkouts_ApplicationUserId",
                table: "UserWorkouts");

            migrationBuilder.DropIndex(
                name: "IX_MaxLifts_ApplicationUserId",
                table: "MaxLifts");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UserWorkouts");

            migrationBuilder.DropColumn(
                name: "MaxBench",
                table: "UserWorkouts");

            migrationBuilder.DropColumn(
                name: "MaxDeadLift",
                table: "UserWorkouts");

            migrationBuilder.DropColumn(
                name: "MaxSquat",
                table: "UserWorkouts");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "UserWorkouts");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaxLifts_ApplicationUserId",
                table: "MaxLifts",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ApplicationUserId",
                table: "Categories",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AspNetUsers_ApplicationUserId",
                table: "Categories",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
