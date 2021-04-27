using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymBuddy.Migrations
{
    public partial class updateTableWithAllThreeWorkoutTypes1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserWorkouts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserWorkouts",
                columns: table => new
                {
                    UserWorkoutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaxBench = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MaxDeadLift = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MaxSquat = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkoutDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWorkouts", x => x.UserWorkoutId);
                    table.ForeignKey(
                        name: "FK_UserWorkouts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkouts_ApplicationUserId",
                table: "UserWorkouts",
                column: "ApplicationUserId");
        }
    }
}
