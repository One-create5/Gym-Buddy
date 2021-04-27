using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymBuddy.Migrations
{
    public partial class updateTableWithAllThreeWorkoutTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BodyBuildingWorkouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkoutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxBench = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MaxSquat = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MaxDeadLift = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyBuildingWorkouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BodyBuildingWorkouts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PowerBuildingWorkouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkoutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxBench = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MaxSquat = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MaxDeadLift = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerBuildingWorkouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PowerBuildingWorkouts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PowerliftWorkouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkoutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxBench = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MaxSquat = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MaxDeadLift = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerliftWorkouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PowerliftWorkouts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BodyBuildingWorkouts_ApplicationUserId",
                table: "BodyBuildingWorkouts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PowerBuildingWorkouts_ApplicationUserId",
                table: "PowerBuildingWorkouts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PowerliftWorkouts_ApplicationUserId",
                table: "PowerliftWorkouts",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BodyBuildingWorkouts");

            migrationBuilder.DropTable(
                name: "PowerBuildingWorkouts");

            migrationBuilder.DropTable(
                name: "PowerliftWorkouts");
        }
    }
}
