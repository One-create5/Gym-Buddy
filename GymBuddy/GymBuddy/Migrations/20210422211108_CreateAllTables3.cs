using Microsoft.EntityFrameworkCore.Migrations;

namespace GymBuddy.Migrations
{
    public partial class CreateAllTables3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_WorkoutExercises_WorkoutExerciseId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_WorkoutExercises_WorkoutExerciseId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_MaxLifts_WorkoutExercises_WorkoutExerciseId",
                table: "MaxLifts");

            migrationBuilder.DropIndex(
                name: "IX_MaxLifts_WorkoutExerciseId",
                table: "MaxLifts");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_WorkoutExerciseId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Categories_WorkoutExerciseId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "WorkoutExerciseId",
                table: "MaxLifts");

            migrationBuilder.DropColumn(
                name: "WorkoutExerciseId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "WorkoutExerciseId",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "WorkoutExercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "WorkoutExercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxLiftId",
                table: "WorkoutExercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserWorkoutId",
                table: "WorkoutExercises",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExercises_CategoryId",
                table: "WorkoutExercises",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExercises_ExerciseId",
                table: "WorkoutExercises",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExercises_MaxLiftId",
                table: "WorkoutExercises",
                column: "MaxLiftId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExercises_UserWorkoutId",
                table: "WorkoutExercises",
                column: "UserWorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutExercises_Categories_CategoryId",
                table: "WorkoutExercises",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutExercises_Exercises_ExerciseId",
                table: "WorkoutExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "ExerciseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutExercises_MaxLifts_MaxLiftId",
                table: "WorkoutExercises",
                column: "MaxLiftId",
                principalTable: "MaxLifts",
                principalColumn: "MaxLiftId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutExercises_UserWorkouts_UserWorkoutId",
                table: "WorkoutExercises",
                column: "UserWorkoutId",
                principalTable: "UserWorkouts",
                principalColumn: "UserWorkoutId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutExercises_Categories_CategoryId",
                table: "WorkoutExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutExercises_Exercises_ExerciseId",
                table: "WorkoutExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutExercises_MaxLifts_MaxLiftId",
                table: "WorkoutExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutExercises_UserWorkouts_UserWorkoutId",
                table: "WorkoutExercises");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutExercises_CategoryId",
                table: "WorkoutExercises");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutExercises_ExerciseId",
                table: "WorkoutExercises");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutExercises_MaxLiftId",
                table: "WorkoutExercises");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutExercises_UserWorkoutId",
                table: "WorkoutExercises");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "WorkoutExercises");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "WorkoutExercises");

            migrationBuilder.DropColumn(
                name: "MaxLiftId",
                table: "WorkoutExercises");

            migrationBuilder.DropColumn(
                name: "UserWorkoutId",
                table: "WorkoutExercises");

            migrationBuilder.AddColumn<int>(
                name: "WorkoutExerciseId",
                table: "MaxLifts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutExerciseId",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutExerciseId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MaxLifts_WorkoutExerciseId",
                table: "MaxLifts",
                column: "WorkoutExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_WorkoutExerciseId",
                table: "Exercises",
                column: "WorkoutExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_WorkoutExerciseId",
                table: "Categories",
                column: "WorkoutExerciseId");

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
    }
}
