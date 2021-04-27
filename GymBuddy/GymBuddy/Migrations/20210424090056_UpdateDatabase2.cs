using Microsoft.EntityFrameworkCore.Migrations;

namespace GymBuddy.Migrations
{
    public partial class UpdateDatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWorkouts_Categories_CategoryId",
                table: "UserWorkouts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_UserWorkouts_CategoryId",
                table: "UserWorkouts");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "WorkoutExercises");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "UserWorkouts");

            migrationBuilder.AddColumn<decimal>(
                name: "OneRepMax",
                table: "WorkoutExercises",
                type: "decimal(5,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RPE",
                table: "WorkoutExercises",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OneRepMax",
                table: "WorkoutExercises");

            migrationBuilder.DropColumn(
                name: "RPE",
                table: "WorkoutExercises");

            migrationBuilder.AddColumn<decimal>(
                name: "Weight",
                table: "WorkoutExercises",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "UserWorkouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

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
    }
}
