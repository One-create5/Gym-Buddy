using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymBuddy.Migrations
{
    public partial class CreateAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserWorkoutId",
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

            migrationBuilder.CreateTable(
                name: "UserWorkout",
                columns: table => new
                {
                    UserWorkoutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkoutDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWorkout", x => x.UserWorkoutId);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutExercise",
                columns: table => new
                {
                    WorkoutExerciseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reps = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutExercise", x => x.WorkoutExerciseId);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkoutExerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.ExerciseId);
                    table.ForeignKey(
                        name: "FK_Exercise_WorkoutExercise_WorkoutExerciseId",
                        column: x => x.WorkoutExerciseId,
                        principalTable: "WorkoutExercise",
                        principalColumn: "WorkoutExerciseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaxLift",
                columns: table => new
                {
                    MaxLiftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxBench = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MaxSquat = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MaxDeadLift = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    WorkoutExerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaxLift", x => x.MaxLiftId);
                    table.ForeignKey(
                        name: "FK_MaxLift_WorkoutExercise_WorkoutExerciseId",
                        column: x => x.WorkoutExerciseId,
                        principalTable: "WorkoutExercise",
                        principalColumn: "WorkoutExerciseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UserWorkoutId",
                table: "Categories",
                column: "UserWorkoutId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_WorkoutExerciseId",
                table: "Categories",
                column: "WorkoutExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_WorkoutExerciseId",
                table: "Exercise",
                column: "WorkoutExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_MaxLift_WorkoutExerciseId",
                table: "MaxLift",
                column: "WorkoutExerciseId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_UserWorkout_UserWorkoutId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_WorkoutExercise_WorkoutExerciseId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "MaxLift");

            migrationBuilder.DropTable(
                name: "UserWorkout");

            migrationBuilder.DropTable(
                name: "WorkoutExercise");

            migrationBuilder.DropIndex(
                name: "IX_Categories_UserWorkoutId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_WorkoutExerciseId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UserWorkoutId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "WorkoutExerciseId",
                table: "Categories");
        }
    }
}
