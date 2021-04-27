using Microsoft.EntityFrameworkCore.Migrations;

namespace GymBuddy.Migrations
{
    public partial class updateTableWithAllThreeWorkoutTypes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationId",
                table: "PowerliftWorkouts",
                type: "nvarchar(max)",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationId",
                table: "PowerBuildingWorkouts",
                type: "nvarchar(max)",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationId",
                table: "BodyBuildingWorkouts",
                type: "nvarchar(max)",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "PowerliftWorkouts");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "PowerBuildingWorkouts");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "BodyBuildingWorkouts");
        }
    }
}
