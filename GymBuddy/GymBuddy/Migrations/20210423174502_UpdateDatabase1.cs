using Microsoft.EntityFrameworkCore.Migrations;

namespace GymBuddy.Migrations
{
    public partial class UpdateDatabase1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutExercises_MaxLifts_MaxLiftId",
                table: "WorkoutExercises");

            migrationBuilder.DropTable(
                name: "MaxLifts");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutExercises_MaxLiftId",
                table: "WorkoutExercises");

            migrationBuilder.DropColumn(
                name: "MaxLiftId",
                table: "WorkoutExercises");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxLiftId",
                table: "WorkoutExercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MaxLifts",
                columns: table => new
                {
                    MaxLiftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaxBench = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MaxDeadLift = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MaxSquat = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaxLifts", x => x.MaxLiftId);
                    table.ForeignKey(
                        name: "FK_MaxLifts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExercises_MaxLiftId",
                table: "WorkoutExercises",
                column: "MaxLiftId");

            migrationBuilder.CreateIndex(
                name: "IX_MaxLifts_ApplicationUserId",
                table: "MaxLifts",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutExercises_MaxLifts_MaxLiftId",
                table: "WorkoutExercises",
                column: "MaxLiftId",
                principalTable: "MaxLifts",
                principalColumn: "MaxLiftId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
