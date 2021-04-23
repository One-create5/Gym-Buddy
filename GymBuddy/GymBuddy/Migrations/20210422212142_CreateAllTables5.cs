using Microsoft.EntityFrameworkCore.Migrations;

namespace GymBuddy.Migrations
{
    public partial class CreateAllTables5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_UserWorkouts_UserWorkoutId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_UserWorkoutId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UserWorkoutId",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "UserWorkouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkouts_CategoryId",
                table: "UserWorkouts",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserWorkouts_Categories_CategoryId",
                table: "UserWorkouts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWorkouts_Categories_CategoryId",
                table: "UserWorkouts");

            migrationBuilder.DropIndex(
                name: "IX_UserWorkouts_CategoryId",
                table: "UserWorkouts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "UserWorkouts");

            migrationBuilder.AddColumn<int>(
                name: "UserWorkoutId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UserWorkoutId",
                table: "Categories",
                column: "UserWorkoutId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_UserWorkouts_UserWorkoutId",
                table: "Categories",
                column: "UserWorkoutId",
                principalTable: "UserWorkouts",
                principalColumn: "UserWorkoutId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
