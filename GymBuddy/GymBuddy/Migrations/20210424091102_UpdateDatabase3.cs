using Microsoft.EntityFrameworkCore.Migrations;

namespace GymBuddy.Migrations
{
    public partial class UpdateDatabase3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutExercises_UserWorkouts_UserWorkoutId",
                table: "WorkoutExercises");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutExercises_UserWorkoutId",
                table: "WorkoutExercises");

            migrationBuilder.DropColumn(
                name: "UserWorkoutId",
                table: "WorkoutExercises");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserWorkoutId",
                table: "WorkoutExercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExercises_UserWorkoutId",
                table: "WorkoutExercises",
                column: "UserWorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutExercises_UserWorkouts_UserWorkoutId",
                table: "WorkoutExercises",
                column: "UserWorkoutId",
                principalTable: "UserWorkouts",
                principalColumn: "UserWorkoutId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
