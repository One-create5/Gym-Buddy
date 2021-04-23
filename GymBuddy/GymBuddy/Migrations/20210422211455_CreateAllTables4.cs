using Microsoft.EntityFrameworkCore.Migrations;

namespace GymBuddy.Migrations
{
    public partial class CreateAllTables4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutExercises_Categories_CategoryId",
                table: "WorkoutExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutExercises_UserWorkouts_UserWorkoutId",
                table: "WorkoutExercises");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutExercises_CategoryId",
                table: "WorkoutExercises");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "WorkoutExercises");

            migrationBuilder.AlterColumn<int>(
                name: "UserWorkoutId",
                table: "WorkoutExercises",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutExercises_UserWorkouts_UserWorkoutId",
                table: "WorkoutExercises",
                column: "UserWorkoutId",
                principalTable: "UserWorkouts",
                principalColumn: "UserWorkoutId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutExercises_UserWorkouts_UserWorkoutId",
                table: "WorkoutExercises");

            migrationBuilder.AlterColumn<int>(
                name: "UserWorkoutId",
                table: "WorkoutExercises",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "WorkoutExercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExercises_CategoryId",
                table: "WorkoutExercises",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutExercises_Categories_CategoryId",
                table: "WorkoutExercises",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutExercises_UserWorkouts_UserWorkoutId",
                table: "WorkoutExercises",
                column: "UserWorkoutId",
                principalTable: "UserWorkouts",
                principalColumn: "UserWorkoutId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
