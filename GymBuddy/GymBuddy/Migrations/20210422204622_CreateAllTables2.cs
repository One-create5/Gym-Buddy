using Microsoft.EntityFrameworkCore.Migrations;

namespace GymBuddy.Migrations
{
    public partial class CreateAllTables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_UserWorkout_UserWorkoutId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_WorkoutExercise_WorkoutExerciseId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_WorkoutExercise_WorkoutExerciseId",
                table: "Exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_MaxLift_WorkoutExercise_WorkoutExerciseId",
                table: "MaxLift");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutExercise",
                table: "WorkoutExercise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserWorkout",
                table: "UserWorkout");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaxLift",
                table: "MaxLift");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise");

            migrationBuilder.RenameTable(
                name: "WorkoutExercise",
                newName: "WorkoutExercises");

            migrationBuilder.RenameTable(
                name: "UserWorkout",
                newName: "UserWorkouts");

            migrationBuilder.RenameTable(
                name: "MaxLift",
                newName: "MaxLifts");

            migrationBuilder.RenameTable(
                name: "Exercise",
                newName: "Exercises");

            migrationBuilder.RenameIndex(
                name: "IX_MaxLift_WorkoutExerciseId",
                table: "MaxLifts",
                newName: "IX_MaxLifts_WorkoutExerciseId");

            migrationBuilder.RenameIndex(
                name: "IX_Exercise_WorkoutExerciseId",
                table: "Exercises",
                newName: "IX_Exercises_WorkoutExerciseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutExercises",
                table: "WorkoutExercises",
                column: "WorkoutExerciseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserWorkouts",
                table: "UserWorkouts",
                column: "UserWorkoutId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaxLifts",
                table: "MaxLifts",
                column: "MaxLiftId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_UserWorkouts_UserWorkoutId",
                table: "Categories",
                column: "UserWorkoutId",
                principalTable: "UserWorkouts",
                principalColumn: "UserWorkoutId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_WorkoutExercises_WorkoutExerciseId",
                table: "Categories",
                column: "WorkoutExerciseId",
                principalTable: "WorkoutExercises",
                principalColumn: "WorkoutExerciseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_WorkoutExercises_WorkoutExerciseId",
                table: "Exercises",
                column: "WorkoutExerciseId",
                principalTable: "WorkoutExercises",
                principalColumn: "WorkoutExerciseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaxLifts_WorkoutExercises_WorkoutExerciseId",
                table: "MaxLifts",
                column: "WorkoutExerciseId",
                principalTable: "WorkoutExercises",
                principalColumn: "WorkoutExerciseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_UserWorkouts_UserWorkoutId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_WorkoutExercises_WorkoutExerciseId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_WorkoutExercises_WorkoutExerciseId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_MaxLifts_WorkoutExercises_WorkoutExerciseId",
                table: "MaxLifts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutExercises",
                table: "WorkoutExercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserWorkouts",
                table: "UserWorkouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaxLifts",
                table: "MaxLifts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises");

            migrationBuilder.RenameTable(
                name: "WorkoutExercises",
                newName: "WorkoutExercise");

            migrationBuilder.RenameTable(
                name: "UserWorkouts",
                newName: "UserWorkout");

            migrationBuilder.RenameTable(
                name: "MaxLifts",
                newName: "MaxLift");

            migrationBuilder.RenameTable(
                name: "Exercises",
                newName: "Exercise");

            migrationBuilder.RenameIndex(
                name: "IX_MaxLifts_WorkoutExerciseId",
                table: "MaxLift",
                newName: "IX_MaxLift_WorkoutExerciseId");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_WorkoutExerciseId",
                table: "Exercise",
                newName: "IX_Exercise_WorkoutExerciseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutExercise",
                table: "WorkoutExercise",
                column: "WorkoutExerciseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserWorkout",
                table: "UserWorkout",
                column: "UserWorkoutId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaxLift",
                table: "MaxLift",
                column: "MaxLiftId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_UserWorkout_UserWorkoutId",
                table: "Categories",
                column: "UserWorkoutId",
                principalTable: "UserWorkout",
                principalColumn: "UserWorkoutId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_WorkoutExercise_WorkoutExerciseId",
                table: "Categories",
                column: "WorkoutExerciseId",
                principalTable: "WorkoutExercise",
                principalColumn: "WorkoutExerciseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_WorkoutExercise_WorkoutExerciseId",
                table: "Exercise",
                column: "WorkoutExerciseId",
                principalTable: "WorkoutExercise",
                principalColumn: "WorkoutExerciseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaxLift_WorkoutExercise_WorkoutExerciseId",
                table: "MaxLift",
                column: "WorkoutExerciseId",
                principalTable: "WorkoutExercise",
                principalColumn: "WorkoutExerciseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
